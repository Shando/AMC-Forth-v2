using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckGetRowDataDollar : Words
    {
        public DuckGetRowDataDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKGETROWDATA$";
            Description =
                "Gets the data returned after calling DUCKRUNQUERY or DUCKRUNQUERY$.<br/>"
                + "Puts the value at 'row' (an integer value starting at 0 for the first row), and 'col'"
                + " (a string variable representing the name of the column in the results), from the returned dataset, onto the stack.<br/>"
                + "NOTE: If 'row' is outside the bounds of the results, or 'col' is not a valid column name, then this will put '-1' on the stack.<br/>"
                + "NOTE1: If the returned value is an integer or a boolean, then this will put the 'value' of the integer / boolean and '0' on the stack.<br/>"
                + "NOTE2: If the returned value is a string, date / time, or any type of decimal value, then this will put the 'c-addr' and the"
                + " 'length' of the string (with dates and decimals being converted to strings), and '1' on the stack.<br/>"
                + "Example usage: myCol 4 DUCKGETROWDATA$";
            StackEffect = "( col row -- -1 ) or " +
                          "( col row -- value 0 ) or " +
                          "( col row -- c-addr length 1 )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            int row = Stack.Pop();
            Forth.CoreWords.Fetch.Call();
            int a0 = Stack.Pop();               // address of Column Name
            int n0 = Forth.Ram.GetInt(a0 - 4);  // curlen of Column Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Words.bRunning = true;
            Forth.bg.CallDeferred("getRowData", row, s0);
        }
    }
}
