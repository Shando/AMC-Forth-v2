using Godot;

namespace Forth.AMCExt
{
    [GlobalClass]
    public partial class PStop : Words
    {
        public PStop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "P-STOP";
            Description = "Stop periodic timer with id i.";
            StackEffect = "( i - )";
        }

        public override void Call()
        {
            Forth.AMCExtWords.PTimerX.GetTimerAddress();
            // ( i - addr )
            var addr = Stack.Pop();
            // ( addr - )
            // clear the entries for the given timer id
            Forth.Ram.SetInt(addr, 0);
            Forth.Ram.SetInt(addr + RAM.CellSize, 0);
            // the next time this timer expires, the system will find nothing
            // here for the ID, and it will be cancelled.
        }
    }
}