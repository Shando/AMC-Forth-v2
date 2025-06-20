using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckConvertIntToReal : Words
    {
        public DuckConvertIntToReal(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKINT2REAL";
            Description =
                "Converts an integer to a string based 'real' and stores it in the denoted string variable 'strvar'.<br/>"
                + "NOTE: 'strvar' is a string variable that must have already been declared using VAR$.<br/>"
                + "Example usage: int strvar DUCKINT2REAL";
            StackEffect = "( int var -- )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            int v = Stack.Pop();                // start address of variable
            int i = Stack.Pop();                // integer value
            string sI = i.ToString();
            sI += ".00";
            int j = 0;

            foreach (char c in sI)         // just copy it at the end of the dictionary as a temporary area
            {
                byte b = (byte)c;
                Forth.Ram.SetByte(Forth.DictTopP + j, b);
                j++;
            }

            // push the return values back onto the stack
            Stack.Push(Forth.DictTopP);
            Stack.Push(sI.Length);
            Stack.Push(v);

            Forth.ShandoWords.SetDollar.Call();
        }
    }
}
