using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forth;
using Godot;
using Godot.Collections;
using static AMCForth;

[GlobalClass]
public partial class AMCForth : RefCounted
{
	[Signal]
	public delegate void TerminalOutEventHandler(string text);

	[Signal]
	public delegate void TerminalInReadyEventHandler();

	// Control flow address types
	public enum CFType
	{
		Orig,
		Dest,
	}

	// Input event handling modes
	public enum QueueMode
	{
		QueueAlways = 0, // If listening, ALWAYS enqueue new events (e.g. serial data)
		QueueChanges = 1, // If listening, only enqueue new events with changed value (e.g. want to see changes)
		QueueReplace = 2, // If listening, replace previous queued events on this port (e.g. only want latest state)
	}

	public const string Banner = "AMC Forth";
	public const string ConfigFileName = "user://ForthState.cfg";
	public const string DefaultForthSourcesPath = "res://";
	public string lastWord = "";

	// Add more pointers here
	public const int True = -1;
	public const int False = 0;

	public bool bRun = false;
	public bool bQuit = false;

	// Size of terminal command history
	public const int MaxBufferSize = 20;

	// Masks for built-in execution tokens
	public const uint XtUnusedMask = 0x80000000;
	public const uint BuiltInXtMask = 0x040000000;
	public const uint BuiltInXtXMask = 0x020000000;

	// Built-in name management
	public Godot.Collections.Dictionary<string, Words> BuiltinNameDict = [];
	public Godot.Collections.Dictionary<int, Words> BuiltinXtDict = [];

	public List<string> AllBuiltinNames
	{
		get => [.. BuiltinNameDict.Keys];
	}

	// Get builtin word implementation from its name
	public Words BuiltinFromName(string name)
	{
		if (BuiltinNameDict.ContainsKey(name))
		{
			return BuiltinNameDict[name];
		}
		else
		{
			throw new ArgumentOutOfRangeException(name + ": Name is not recognised as a Forth built-in.");
		}
	}

	public const uint BuiltInMask = ~(XtUnusedMask | BuiltInXtMask | BuiltInXtXMask);

	// Smudge bit mask
	public const int SmudgeBitMask = 0x80;

	// Immediate bit mask
	public const int ImmediateBitMask = 0x40;

	// Largest name length
	public const int MaxNameLength = 0x3f;

	// Forth secondary source directory
	public string ForthSourcesPath;

	// Reference to the physical memory and utilities
	public RAM Ram;
	public Util Util;
	public Stack Stack;
	public Files Files;
	public int MapVersion;

	// Forth Word Classes
	public Forth.AMCExt.AMCExtSet AMCExtWords;
	public Forth.CommonUse.CommonUseSet CommonUseWords;
	public Forth.Core.CoreSet CoreWords;
	public Forth.CoreExt.CoreExtSet CoreExtWords;
	public Forth.Double.DoubleSet DoubleWords;
	public Forth.DoubleExt.DoubleExtSet DoubleExtWords;
	public Forth.DuckDb.DuckDbSet DuckDbWords;
	public Forth.Facility.FacilitySet FacilityWords;
	public Forth.File.FileSet FileWords;
	public Forth.FileExt.FileExtSet FileExtWords;
	public Forth.Graphics.GraphicsSet GraphicsWords;
	public Forth.Shando.ShandoSet ShandoWords;
	public Forth.Sound.SoundSet SoundWords;
	//public Forth.SQLite.SQLiteSet SQLiteWords;
	public Forth.String.StringSet StringWords;
	public Forth.Tools.ToolsSet ToolsWords;
	public Forth.ToolsExt.ToolsExtSet ToolsExtWords;

	// The Forth data stack pointer is in byte units
	// The Forth dictionary space
	public int DictP;

	// position of last link
	public int DictTopP;

	// position of next new link to create
	public int DictIp = 0;

	// code field pointer set to current execution point
	// Forth compile state
	public bool State = false;

	// Forth source ID
	public int SourceId = 0;

	// 0 default, -1 ram buffer, else file id
	public Stack<int> SourceIdStack = new();

	// pointer for constructing formatted numbers
	public int NumFormatBuffPointer = 0;

	// Forth : exit flag (true if exit has been called)
	public bool ExitFlag = false;

	// Structure of an output port signal (owner, event name)
	public readonly struct OutputPortSignal
	{
		public OutputPortSignal(GodotObject owner, Godot.StringName signal)
		{
			Owner = owner;
			Signal = signal;
		}

		public GodotObject Owner { get; }
		public StringName Signal { get; }
		public override string ToString() => $"({Owner}, {Signal})";
	}

	// Map output port ID to user signal data
	public System.Collections.Generic.Dictionary<int, List<OutputPortSignal>> OutputPortMap = [];

	// structure of an input port event (port id, data value)
	public readonly struct PortEvent
	{
		public PortEvent(int port, int value)
		{
			Port = port;
			Value = value;
		}

		public int Port { get; }
		public int Value { get; }
		public override string ToString() => $"({Port}, {Value})";
	}

	// Input event list of incoming PortEvent data
	public List<PortEvent> InputPortEvents = [];
	private Mutex InputPortMutex; // Protect access to input port structures in RAM
	private Mutex RamMutex; // Protect external access to RAM image

	public struct TimerStruct
	{
		public TimerStruct(int msec, int xt, Timer timer)
		{
			MSec = (uint)msec;
			Xt = xt;
			Timer = timer;
			Start = Time.GetTicksMsec();
			Correction = 0;
		}

		public uint MSec { get; }
		public int Xt { get; }
		public Timer Timer { get; }
		public ulong Start { get; set; } // system msec when timer is first started
		public int Correction { get; set; } // msec correction currently applied
		public override string ToString()
		{
			return $"({MSec}, {Xt}, {Timer}, {Start}, {Correction})";
		}
	}

	// Periodic timer list
	public System.Collections.Generic.Dictionary<int, TimerStruct> PeriodicTimerMap = [];

	// Timer events queue
	public Queue<int> TimerEvents = new();

	// Owning Node
	protected Node _Node;
	protected bool OwnerNodeIsGdscript;
	protected string OwnerAddChild;
	protected string OwnerRemoveChild;

	// State file
	protected ConfigFile _Config;

	protected bool _DataStackUnderflow = false;

	// terminal scratchpad and buffer
	public string _TerminalPad = "";
	protected int _PadPosition = 0;
	protected int _ParsePointer = 0;
	protected List<string> _TerminalBuffer = [];
	protected int _BufferIndex = 0;

	// Forth : execution dict_ip stack
	protected Stack<int> _DictIpStack = new();

	public readonly struct ControlFlowItem
	{
		public ControlFlowItem(CFType type, int addr)
		{
			AddrType = type;
			Addr = addr;
		}

		public CFType AddrType { get; }
		public int Addr { get; }
		public override string ToString() => $"({AddrType}, {Addr})";
	}

	// Forth: control flow stack. Entries are in the form
	// [orig | dest, address]
	protected Stack<ControlFlowItem> _ControlFlowStack = new();

	// Forth: loop control flow stack for LEAVE ORIG entries only!
	protected Stack<int> _LeaveControlFlowStack = new();

	// Thread data
	protected System.Threading.Thread _Thread;
	protected Semaphore _InputReady;
	protected bool _OutputDone;
	protected bool Quit = false;

	// Client connect count
	protected int _ClientConnections = 0;

	public Control main;

	// Foreground and Background for Graphics
	public Node2D fg;
	public Node2D bg;
	public int[] AtXYG = new int[2];

	public AudioStreamPlayer music;
	public AudioStreamPlayer sfx;

	public void ClientConnected()
	{
		if (_ClientConnections == 0)
		{
			EmitSignal("TerminalOut", GetBanner() + Terminal.CRLF);
			_ClientConnections += 1;
		}
	}

	// pause until Forth is ready to accept input
	public bool IsReadyForInput()
	{
		return _OutputDone;
	}

	// preserve Forth memory and state
	public void SaveSnapshot()
	{
		_Config.Clear();
		SaveState(_Config);
		_Config.Save(ConfigFileName);
	}

	// restore Forth memory and state
	public void LoadSnapshot()
	{
		_Config.Load(ConfigFileName);
		LoadState(_Config);
	}

	public void SaveState(ConfigFile Config, string Section = "ram", string Key = "image")
	{
		RamMutex.Lock(); // no collision with Forth thread
		Files.CloseAllFiles();
		Ram.SaveState(Config, Section, Key);
		RamMutex.Unlock();
	}

	// restore Forth memory and state
	public void LoadState(ConfigFile Config, string Section = "ram", string Key = "image")
	{
		RamMutex.Lock(); // no collision with Forth thread
		// stop all periodic timers
		RemoveAllTimers();
		Ram.LoadState(Config, Section, Key);
		// restore shadowed registers
		RestoreDictP();
		RestoreDictTop();
		// start all configured periodic timers
		RestoreAllTimers();
		RamMutex.Unlock();
	}

	// handle editing input strings in interactive mode
	public void TerminalIn(string text, bool bIn)
	{
		bRun = bIn;
		var in_str = text;
		var echo_text = "";
		var buffer_size = _TerminalBuffer.Count;

		while (in_str.Length > 0)
		{
			if (in_str.Find(Terminal.DEL_LEFT) == 0)
			{
				_PadPosition = Mathf.Max(0, _PadPosition - 1);

				if (_TerminalPad.Length != 0)
				{
					// shrink if deleting from end, else replace with space
					if (_PadPosition == _TerminalPad.Length - 1)
					{
						_TerminalPad = _TerminalPad.Left(_PadPosition);
					}
					else
					{
						_TerminalPad =
							string.Concat(_TerminalPad.Left(_PadPosition),
							" ",
							_TerminalPad.AsSpan(_PadPosition + 1));
					}
				}

				// reconstruct the changed entry, with correct cursor position
				//echo_text = RefreshEditText();
				in_str = in_str[Terminal.DEL_LEFT.Length..];
			}
			else if (in_str.Find(Terminal.DEL) == 0)
			{
				// do nothing unless cursor is in text
				if (_PadPosition <= _TerminalPad.Length)
				{
					_TerminalPad =
						string.Concat(_TerminalPad.Left(_PadPosition), _TerminalPad.AsSpan(_PadPosition + 1));
				}

				// reconstruct the changed entry, with correct cursor position
				//echo_text = RefreshEditText();
				in_str = in_str[Terminal.DEL.Length..];
			}
			else if (in_str.Find(Terminal.LEFT) == 0)
			{
				_PadPosition = Mathf.Max(0, _PadPosition - 1);
				echo_text = Terminal.LEFT;
				in_str = in_str[Terminal.LEFT.Length..];
			}
			else if (in_str.Find(Terminal.RIGHT) == 0)
			{
				_PadPosition += 1;

				if (_PadPosition > _TerminalPad.Length)
				{
					_PadPosition = _TerminalPad.Length;
				}
				else
				{
					echo_text = Terminal.RIGHT;
				}

				in_str = in_str[Terminal.RIGHT.Length..];
			}
			else if (in_str.Find(Terminal.UP) == 0)
			{
				if (buffer_size != 0)
				{
					_BufferIndex = Mathf.Max(0, _BufferIndex - 1);
					echo_text = SelectBufferedCommand();
				}

				in_str = in_str[Terminal.UP.Length..];
			}
			else if (in_str.Find(Terminal.DOWN) == 0)
			{
				if (buffer_size != 0)
				{
					_BufferIndex = Mathf.Min(_TerminalBuffer.Count - 1, _BufferIndex + 1);
					echo_text = SelectBufferedCommand();
				}

				in_str = in_str[Terminal.DOWN.Length..];
			}
			else if (in_str.Find(Terminal.LF) == 0)
			{
				echo_text = "";
				in_str = in_str[Terminal.LF.Length..];
			}
			else if (in_str.Find(Terminal.CR) == 0)
			{
				// only add to the buffer if it's different from the top entry
				// and not blank!
				if ((_TerminalPad.Length != 0)
					&& ((buffer_size == 0)
						|| (_TerminalBuffer[^1] != _TerminalPad)))
				{
					_TerminalBuffer.Add(_TerminalPad);

					// if we just grew too big...
					if (buffer_size == MaxBufferSize)
					{
						_TerminalBuffer.RemoveAt(0);
					}
				}

				_BufferIndex = _TerminalBuffer.Count;
				// refresh the line in the terminal
				_PadPosition = _TerminalPad.Length;
				//EmitSignal("TerminalOut", RefreshEditText());
				// text is ready for the Forth interpreter
				_InputReady.Post();
				in_str = in_str[Terminal.CR.Length..];
			}
			// not a control character(s)
			else
			{
				echo_text = in_str.Left(1);
				in_str = in_str[1..];
				
				if (_PadPosition < _TerminalPad.Length)
				{
					_TerminalPad =
						string.Concat(_TerminalPad.Left(_PadPosition), 
						echo_text,
						_TerminalPad.AsSpan(_PadPosition + 1));
				}
				else
				{
					_TerminalPad += echo_text;
				}

				_PadPosition += 1;
			}

			//EmitSignal("TerminalOut", echo_text + Terminal.CRLF);
		}
	}

	public void emitSignal(string inS)
	{
		EmitSignal("TerminalOut", inS + Terminal.CRLF);
	}

	public readonly struct DictResult
	{
		public DictResult(int addr, bool isImmediate)
		{
			Addr = addr;
			IsImmediate = isImmediate;
		}

		public int Addr { get; }
		public bool IsImmediate { get; }
		public override string ToString() => $"({Addr}, {IsImmediate})";
	}

	// Find word in dictionary, starting at address of top
	// Returns a list consisting of:
	//  > the address of the first code field (zero if not found)
	//  > a boolean true if the word is defined as IMMEDIATE
	public DictResult FindInDict(string word)
	{
		if (DictP == DictTopP)
		{
			// dictionary is empty
			return new(0, false);
		}

		// stuff the search string in data memory
		Util.CstringFromStr(Map.DictBuffStart, word);
		// make a temporary pointer
		var p = DictP;

		while (p != -1) // <empty>
		{
			Stack.Push(Map.DictBuffStart); // c-addr
			CoreWords.Count.Call(); // search word in addr  # addr n
			Stack.Push(p + RAM.CellSize); // entry name  # addr n c-addr
			CoreWords.Count.Call(); // candidate word in addr			# addr n addr n
			var n_raw_length = Stack.Pop(); // addr n addr
			var n_length = n_raw_length & ~(SmudgeBitMask | ImmediateBitMask);
			Stack.Push(n_length); // strip the SMUDGE and IMMEDIATE bits and restore # addr n addr n
			
			// only check if the entry has a clear smudge bit
			if ((n_raw_length & SmudgeBitMask) == 0)
			{
				StringWords.Compare.Call();

				// is this the correct entry?
				if (Stack.Pop() == 0)
				{
					// found it. Link address + link size + string length byte + string, aligned
					Stack.Push(p + RAM.CellSize + 1 + n_length); // n
					CoreWords.Aligned.Call(); // a
					return new(Stack.Pop(), (n_raw_length & ImmediateBitMask) != 0);
				}
			}
			else
			{
				// clean up the stack
				Stack.PopDword(); // addr n
				Stack.PopDword();
			}

			// not found, drill down to the next entry
			p = Ram.GetInt(p);
		}

		// exhausted the dictionary, finding nothing
		return new(0, false);
	}

	// Internal utility function for creating the start of
	// a dictionary entry. The next thing to follow will be
	// the execution token. Upon exit, dict_top will point to the
	// aligned position of the execution token to be.
	// Accepts an optional smudge state (default false).
	// Returns the address of the name length byte or zero on fail.
	public int CreateDictEntryName(bool smudge = false)
	{
		// ( - )
		// Grab the name
		CoreExtWords.ParseName.Call();
		var len = Stack.Pop(); // length
		var caddr = Stack.Pop(); // start

		if (len <= MaxNameLength)
		{
			// poke address of last link at next spot, but only if this isn't
			// the very first spot in the dictionary
			if (DictTopP != DictP)
			{
				// align the top pointer, so link will be word-aligned
				CoreWords.Align.Call();
				Ram.SetInt(DictTopP, DictP);
			}

			// move the top link
			DictP = DictTopP;
			SaveDictP();
			DictTopP += RAM.CellSize;
			// poke the name length, with a smudge bit if needed
			var smudge_bit = (smudge ? SmudgeBitMask : 0);
			Ram.SetByte(DictTopP, len | smudge_bit);
			// preserve the address of the length byte
			var ret = DictTopP;
			DictTopP += 1;
			// copy the name
			Stack.Push(caddr);
			Stack.Push(DictTopP);
			Stack.Push(len);
			CoreWords.Move.Call();
			DictTopP += len;
			CoreWords.Align.Call(); // will save dict_top
			// the address of the name length byte
			return ret;
		}

		return 0;
	}

	// Unwind pointers and stacks to reverse the effect of any
	// colon definition currently underway.
	public void UnwindCompile()
	{
		if (State)
		{
			State = false;
			// reset the control flow stack
			CfReset();
			// restore the original dictionary state
			DictTopP = DictP;
			DictP = Ram.GetInt(DictP);
		}
	}

	// Forth Input and Output Interface

	public void AddInputSignal(int port, Signal s)
	{
		new InputReceiver().Initialize(this, port, s);
	}

	// Register an output signal handler (port triggers message out)
	// Message will fire with Forth OUT ( x p - )
	// Multiple signals may be registered to the same output port
	public void AddOutputSignal(int port, Signal s)
	{
		if (!OutputPortMap.ContainsKey(port))
		{
			OutputPortMap[port] = new List<OutputPortSignal>();
		}

		OutputPortMap[port].Add(new OutputPortSignal(s.Owner, s.Name));
	}

	// Utility function to add an input event to the queue
	public void InputEvent(int port, int value)
	{
		var q = (QueueMode)Ram.GetInt(Map.IoInMapStart + RAM.CellSize * (2 * port + 1));
		var item = new PortEvent(port, value);
		bool enqueue = false;
		int i;

		if (q == QueueMode.QueueAlways)
		{
			enqueue = true;
		}
		else
		{
			InputPortMutex.Lock();

			for (i = InputPortEvents.Count - 1; i >= 0; i--)
			{
				var pe = InputPortEvents[i];

				if (pe.Port == item.Port)
				{
					if (q == QueueMode.QueueChanges)
					{
						if (pe.Value != item.Value)
						{
							// this event represents a changed value so enqueue it
							enqueue = true;
						}
					}
					else // QueueMode.QueueReplace
					{
						// replace the last queued event on this port. DON'T enqeue it.
						InputPortEvents[i] = item;
					}

					break; // stop looping
				}
			}

			InputPortMutex.Unlock();

			if (i < 0 && Ram.GetInt(Map.IoInStart + port * RAM.CellSize) != value)
			{
				// exhausted the entire queue without a matching port, and the new
				// value is different from the value currently stored. Enqueue it!
				enqueue = true;
			}
		}

		if (enqueue)
		{
			InputPortMutex.Lock();
			InputPortEvents.Add(item);
			InputPortMutex.Unlock();
			// bump the semaphore count
			_InputReady.Post();
		}
	}

	// Start a periodic timer with id to call an execution token
	// This is only called from within Forth code!
	public void StartPeriodicTimer(int id, int msec, int xt)
	{
		// save info
		var timer = new Timer();
		void signalReceiver() => HandleTimeout(id, timer);
		PeriodicTimerMap[id] = new(msec, xt, timer);
		timer.WaitTime = msec / 1000.0;
		timer.Autostart = true;
		timer.Timeout += signalReceiver;
		_Node.CallDeferred("add_child", timer);
	}

	// Utility function to service periodic timer expirations
	protected void HandleTimeout(int id, Timer timer)
	{
		// Timer events are enqueued, even if there are previous unhandled
		// events on the stack.
		// Check accuracy of timeout and tweak timeout as needed
		if (PeriodicTimerMap.TryGetValue(id, out TimerStruct PeriodicTimer))
		{
			// Only adjust timeout for periods greater than 50 msec
			// See: https://docs.godotengine.org/en/stable/classes/class_timer.html#class-timer-property-wait-time
			if (PeriodicTimer.MSec >= 50)
			{
				var TimerError = (Time.GetTicksMsec() - PeriodicTimer.Start) % PeriodicTimer.MSec;

				if (TimerError != 0)
				{
					if (TimerError <= PeriodicTimer.MSec / 2) // clock was slow
					{
						PeriodicTimer.Correction -= 1; // use a shorter timeout next time
					}
					else
					{
						PeriodicTimer.Correction += 1; // use a longer timeout next time
					}
				}

				var CorrectedTimeout = PeriodicTimer.MSec;

				// only correct timer if the resulting timeout is > 0 and
				// correcting will result in a positive timeout value
				if (PeriodicTimer.Correction != 0
					&& (long)PeriodicTimer.MSec + PeriodicTimer.Correction > 0)
				{
					CorrectedTimeout = (uint)((int)PeriodicTimer.MSec + PeriodicTimer.Correction);
				}

				PeriodicTimer.Timer.WaitTime = CorrectedTimeout / 1000.0;
			}

			TimerEvents.Enqueue(id);
			_InputReady.Post(); // Notify the event thread
		}
		else // id is not found in PeriodicTimerMap - kill the timer
		{
			timer.Stop();
			_Node.CallDeferred("remove_child", timer);
		}
	}

	// Stop a timer without erasing the map entry
	protected void StopTimer(int id)
	{
		var timer = PeriodicTimerMap[id].Timer;
		timer.Stop();
		_Node.CallDeferred("remove_child", timer);
	}

	// Stop a single timer
	protected void RemoveTimer(int id)
	{
		if (PeriodicTimerMap.ContainsKey(id))
		{
			StopTimer(id);
			PeriodicTimerMap.Remove(id);
		}
	}

	// Stop all timers
	protected void RemoveAllTimers()
	{
		foreach (int id in PeriodicTimerMap.Keys)
		{
			StopTimer(id);
		}

		PeriodicTimerMap.Clear();
	}

	// Create and start all configured timers
	protected void RestoreAllTimers()
	{
		for (int id = 0; id < Map.PeriodicTimerQty; id++)
		{
			var addr = Map.PeriodicStart + RAM.CellSize * 2 * id;
			var msec = Ram.GetInt(addr);
			var xt = Ram.GetInt(addr + RAM.CellSize);

			if (xt != 0)
			{
				StartPeriodicTimer(id, msec, xt);
			}
		}
	}

	// save the internal top of dict pointer to RAM
	public void SaveDictTop()
	{
		Ram.SetInt(Map.DictTopPtr, DictTopP);
	}

	// save the internal dict pointer to RAM
	public void SaveDictP()
	{
		Ram.SetInt(Map.DictPtr, DictP);
	}

	// retrieve the internal top of dict pointer from RAM
	public void RestoreDictTop()
	{
		DictTopP = Ram.GetInt(Map.DictTopPtr);
	}

	// retrieve the internal dict pointer from RAM
	public void RestoreDictP()
	{
		DictP = Ram.GetInt(Map.DictPtr);
	}

	// dictionary instruction pointer manipulation
	// push the current dict_ip
	public void PushIp()
	{
		_DictIpStack.Push(DictIp);
	}

	public void PopIp()
	{
		DictIp = _DictIpStack.Pop();
	}

	public bool IpStackIsEmpty()
	{
		return _DictIpStack.Count == 0;
	}

	// compiled word control flow stack

	// reset the stack
	public void CfReset()
	{
		_ControlFlowStack = new();
	}

	public void LcfReset()
	{
		_LeaveControlFlowStack = new();
	}

	protected void _CfPush(ControlFlowItem item)
	{
		_ControlFlowStack.Push(item);
	}

	public void LcfPush(int item)
	{
		_LeaveControlFlowStack.Push(item);
	}

	// push an ORIG word
	public void CfPushOrig(int addr)
	{
		_CfPush(new(CFType.Orig, addr));
	}

	// push an DEST word
	public void CfPushDest(int addr)
	{
		_CfPush(new(CFType.Dest, addr));
	}

	// pop a word
	protected ControlFlowItem _CfPop()
	{
		if (!CfStackIsEmpty())
		{
			return _ControlFlowStack.Pop();
		}

		throw new InvalidOperationException(lastWord + ": Unbalanced control structure detected.");
	}

	public int LcfPop()
	{
		return _LeaveControlFlowStack.Pop();
	}

	// check for items in the leave control flow stack
	public bool LcfIsEmpty()
	{
		return _LeaveControlFlowStack.Count == 0;
	}

	// check for ORIG at top of stack
	public bool CfIsOrig()
	{
		if (_ControlFlowStack.Count > 0)
		{
			return _ControlFlowStack.Peek().AddrType == CFType.Orig;
		}

		return false;
	}

	// check for DEST at top of stack
	public bool CfIsDest()
	{
		if (_ControlFlowStack.Count > 0)
		{
			return _ControlFlowStack.Peek().AddrType == CFType.Dest;
		}

		return false;
	}

	// pop an ORIG word
	public int CfPopOrig()
	{
		if (CfIsOrig())
		{
			return _CfPop().Addr;
		}

		throw new InvalidOperationException(lastWord + ": Control structure expected ORIG but sees DEST.");
	}

	// pop an DEST word
	public int CfPopDest()
	{
		Stack<ControlFlowItem> tempStack = new();
		// move any Orig entries out of the way
		int i = 0;
		
		while (CfIsOrig())
		{
			i++;
			tempStack.Push(_CfPop());
		}

		var CfDestAddr = _CfPop().Addr;
		// put Orig entries back
		for (; i > 0; i--)
		{
			_CfPush(tempStack.Pop());
		}
		
		return CfDestAddr;
	}

	// control flow stack is empty
	public bool CfStackIsEmpty()
	{
		return _ControlFlowStack.Count == 0;
	}

	// control flow stack PICK (implements CS-PICK)
	public void CfStackPick(int item)
	{
		_CfPush(_ControlFlowStack.ToArray()[item]);
	}

	// control flow stack ROLL (implements CS-ROLL)
	public void CfStackRoll(int item)
	{
		Stack<ControlFlowItem> tempStack = new();
		ControlFlowItem temp;

		for (int i = 0; i < item; i++)
		{
			tempStack.Push(_CfPop());
		}

		temp = _CfPop();

		for (int i = 0; i < item; i++)
		{
			_CfPush(tempStack.Pop());
		}

		_CfPush(temp);
	}

	// Set (override) the default secondary forth source file path (normally "res://")
	public void SetSecondarySourceDirectory(string forthSourcesPath)
	{
		ForthSourcesPath = forthSourcesPath;
	}

	// This will cascade instantiation of all the Forth implementation classes
	public void Initialize(Node node)
	{
		// save the instantiating node
		_Node = node;

		// save the default secondary forth source file path
		ForthSourcesPath = DefaultForthSourcesPath;

		InputPortMutex = new();
		RamMutex = new();

		// What kind of node are we living under?
		OwnerNodeIsGdscript = true;
		OwnerAddChild = "add_child";
		OwnerRemoveChild = "remove_child";

		if (_Node.HasMethod("AddChild"))
		{
			OwnerNodeIsGdscript = false;
			OwnerAddChild = "AddChild";
			OwnerRemoveChild = "RemoveChild";
		}

		// seed the randomiser
		GD.Randomize();

		// create a config file
		_Config = new();
		// the top of the dictionary can't overlap the high-memory stuff
		System.Diagnostics.Debug.Assert(Map.TopOfAllocatedRam < Map.PeriodicStart);
		Ram = new();
		Ram.Allocate(Map.RamSize);
		Util = new();
		Util.Initialize(this);
		Stack = new();
		Stack.Initialize(this);
		Files = new();
		Files.Initialize(this);
		MapVersion = Map.Version;

		// Instantiate Forth word definitions
		CommonUseWords = new(this);
		CoreWords = new(this);
		CoreExtWords = new(this);
		DoubleWords = new(this);
		DoubleExtWords = new(this);
		FacilityWords = new(this);
		FileWords = new(this);
		FileExtWords = new(this);
		StringWords = new(this);
		ToolsWords = new(this);
		ToolsExtWords = new(this);
		AMCExtWords = new(this);
		GraphicsWords = new(this);
		SoundWords = new(this);
		ShandoWords = new(this);
		//SQLiteWords = new(this);
		DuckDbWords = new(this);

		// set the terminal link in the dictionary
		Ram.SetInt(DictP, -1);

		// reset the buffer pointer
		Ram.SetInt(Map.BuffToIn, 0);

		// set the base
		CoreWords.Decimal.Call();

		// initialize dictionary pointers and save them to RAM
		DictP = Map.DictStart;
		// position of last link
		SaveDictP();
		DictTopP = Map.DictStart;
		// position of next new link to create
		SaveDictTop();

		if (main == null)
		{
			SceneTree st = (SceneTree)Engine.GetMainLoop();
			Array<Node> nd = st.GetNodesInGroup("Main");

			main = (Control)nd[0];
		}

		// setup graphics
		if (fg == null)
		{
			SceneTree st = (SceneTree)Engine.GetMainLoop();
			Array<Node> nd = st.GetNodesInGroup("Nodes2");

			//if (nd[0].Name == "Foreground")
			if (nd[0].Name == "FG")
			{
				fg = (Node2D)nd[0];
				bg = (Node2D)nd[1];
			}
			else
			{
				bg = (Node2D)nd[0];
				fg = (Node2D)nd[1];
			}
		}

		if (music == null)
		{
			SceneTree st = (SceneTree)Engine.GetMainLoop();
			Array<Node> nd = st.GetNodesInGroup("Music");

			music = (AudioStreamPlayer)nd[0];
		}

		if (sfx == null)
		{
			SceneTree st = (SceneTree)Engine.GetMainLoop();
			Array<Node> nd = st.GetNodesInGroup("Sfx");

			sfx = (AudioStreamPlayer)nd[0];
		}
		
		// Launch the AMC Forth thread
		_Thread = new System.Threading.Thread(InputThread);

		// end test
		_InputReady = new();
		_Thread.Start();
		_OutputDone = true;
	}

	// Shut down this instance gracefully, freeing system resources, etc.
	public void Cleanup()
	{
		// wake up the input thread with nothing to do
		Quit = true;
		_InputReady.Post();
	}

	// AMC Forth name with version
	protected static string GetBanner()
	{
		return Banner + " " + "Ver. " + Forth.Version.Ver;
	}
	protected void InputThread()
	{
		while (!Quit)
		{
			_InputReady.Wait();
			// Obtain RAM Mutex for Forth thread
			RamMutex.Lock();

			// preferentially handle input port signals
			InputPortMutex.Lock();
			var InputEventCount = InputPortEvents.Count;
			InputPortMutex.Unlock();

			if (InputEventCount != 0)
			{
				InputPortMutex.Lock();
				PortEvent evt = InputPortEvents[0]; // pull from the front
				InputPortEvents.RemoveAt(0); // and remove it from the list
				InputPortMutex.Unlock();

				// save the input value to the correct memory address
				Ram.SetInt(Map.IoInStart + evt.Port * RAM.CellSize, evt.Value);

				// only execute handler if there is a Forth execution token
				int xt = Ram.GetInt(Map.IoInMapStart + evt.Port * 2 * RAM.CellSize);

				if (xt != 0)
				{
					try
					{
						Stack.Push(evt.Value); // store the value
						Stack.Push(xt); // store the execution token
						//lastWord = BuiltinXtDict[xt].ToString();
					}
					catch (Exception e)
					{
						Util.RprintTerm($" While posting an input port signal, {e.GetType().Name} : {e.Message}");
					}
					try
					{
						CoreWords.Execute.Call();
					}
					catch (Exception e)
					{
						Util.RprintTerm($" {e.GetType().Name} : {e.Message}");
					}
				}
			}
			// followed by timer timeouts
			else if (TimerEvents.Count != 0)
			{
				var id = TimerEvents.Dequeue();

				// only execute if Forth is still listening on this id
				var xt = Ram.GetInt(Map.PeriodicStart + (id * 2 + 1) * RAM.CellSize);

				if (xt != 0)
				{
					try
					{
						Stack.Push(xt);
					}
					catch (Exception e)
					{
						Util.RprintTerm($" While posting an expired timer, {e.GetType().Name} : {e.Message}");
					}
					try
					{
						CoreWords.Execute.Call();
					}
					catch (Exception e)
					{
						Util.RprintTerm($" {e.GetType().Name} : {e.Message}");
						// Avoid spamming the terminal with exceptions
						CallDeferred("RemoveTimer", id);
					}
				}
				else
				{
					// not listening any longer. remove the timer.
					CallDeferred("RemoveTimer", id);
				}
			}
			else
			{
				// no input events, text available on input
				_OutputDone = false;

				try
				{
					Task.Run(() => InterpretTerminalLine());
					//InterpretTerminalLine();
				}
				catch (Exception e)
				{
					Util.RprintError($" {e.GetType().Name} : {e.Message}");
				}

				_OutputDone = true;
			}

			// Release RAM Mutex
			RamMutex.Unlock();
		}
	}

	// Interpret the _terminal_pad content
	protected void InterpretTerminalLine()
	{
		try
		{
			if (_TerminalPad != "")
			{
				// null terminate the string and convert to byte[]
				var bytes_input = (_TerminalPad + "\u0000").ToAsciiBuffer();
				_TerminalPad = "";
				_PadPosition = 0;

				// transfer to the RAM-based input buffer (accessible to the engine)
				for (int i = 0; i < bytes_input.Length; i++)
					Ram.SetByte(Map.BuffSourceStart + i, bytes_input[i]);

				SourceId = -1;
				CoreWords.Evaluate.Call();

				// If running from the Command Line then bRun == false
				if (!bRun)
					Util.RprintTerm("ok.");
			}
		}
		catch (Exception e)
		{
			Util.RprintError($" {e.GetType().Name} : {e.Message}");
		}
	}

	// return echo text that refreshes the current edit
	protected string RefreshEditText()
	{
		var echo = Terminal.CLRLINE + Terminal.CR + _TerminalPad + Terminal.CR;

		foreach (int i in GD.Range(_PadPosition))
		{
			echo += Terminal.RIGHT;
		}

		return echo;
	}

	protected string SelectBufferedCommand()
	{
		var selected_index = _BufferIndex;
		_TerminalPad = _TerminalBuffer[selected_index];
		_PadPosition = _TerminalPad.Length;
		return Terminal.CLRLINE + Terminal.CR + _TerminalPad;
	}
}
