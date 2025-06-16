using Godot;
using System;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckConvertRealToInt : Words
    {
        public DuckConvertRealToInt(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKREAL2INT";
            Description =
                "Converts a string based 'real' to an integer and pushes it onto the stack."
                + " NOTE: the 'real' will be rounded to the nearest integer."
                + " NOTE2: any error will push 0 onto the stack."
                + " Example usage: strvar DUCKREAL2INT";
            StackEffect = "( var -- int )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            Forth.CoreWords.Fetch.Call();
            int aS = Stack.Pop();               // address of string
            int nS = Forth.Ram.GetInt(aS - 4);  // curlen of string

            string sReal = Forth.Util.StrFromAddrN(aS, nS);

            try
            {
                var myReal = Convert.ToDecimal(sReal);
                var myInt = Convert.ToInt32(myReal);
                Stack.Push(myInt);
                Thread.Sleep(25);
            }
            catch (FormatException)
            {
                Words.bRunning = true;
                var myStr = "[color=#FFA500]DUCKDBERROR: Input string is not a number: " + sReal + ".[/color]\r\n";
                Forth.bg.CallDeferred("updCommands", myStr);
                Stack.Push(0);
            }
            catch (OverflowException)
            {
                Words.bRunning = true;
                var myStr = "[color=#FFA500]DUCKDBERROR: Number cannot fit in a decimal: " + sReal + ".[/color]\r\n";
                Forth.bg.CallDeferred("updCommands", myStr);
                Stack.Push(0);
            }
        }
    }
}
