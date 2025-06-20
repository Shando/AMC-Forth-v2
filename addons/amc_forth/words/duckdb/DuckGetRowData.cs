using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckGetRowData : Words
    {
        public DuckGetRowData(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKGETROWDATA";
            Description =
                "Gets the data returned after calling DUCKRUNQUERY or DUCKRUNQUERY$.<br/>"
                + "Puts the value of 'col' (a string value representing the name of the column in the results, which must have been created with S\"),"
                + " and 'row' (an integer value starting at 0 for the first row), from the returned dataset onto the stack.<br/>"
                + "NOTE: If 'row' is outside the bounds of the results, or 'col' is not a valid column name, then this will put '-1' on the stack.<br/>"
                + "NOTE1: If the returned value is an integer or a boolean, then this will put the 'value' of the integer / boolean and '0' on the stack.<br/>"
                + "NOTE2: If the returned value is a string, date / time, or any type of decimal value, then this will put the 'c-addr' and the"
                + " 'length' of the string (with dates and decimals being converted to strings), and '1' on the stack.<br/>"
                + "Example usage: S\" myCol\" 4 DUCKGETROWDATA";
            StackEffect = "( col-addr col-length row -- -1 ) or " +
                          "( col-addr col-length row -- value 0 ) or " +
                          "( col-addr col-length row -- c-addr length 1 )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            int row = Stack.Pop();
            int n0 = Stack.Pop();   // Length of Column Name
            int a0 = Stack.Pop();   // Address of Column Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Words.bRunning = true;
            Forth.bg.CallDeferred("getRowData", row, s0);
        }
    }
}
