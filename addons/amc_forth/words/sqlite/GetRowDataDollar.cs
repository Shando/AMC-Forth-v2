using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class GetRowDataDollar : Words
    {
        public GetRowDataDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETROWDATA$";
            Description =
                "Gets the data returned after calling SELECTROWS$. Puts the value at 'row' (an integer value"
                + " starting at 0 for the first row), and 'col' (a string variable representing the name of"
                + " the column in the results), from the returned dataset, onto the stack.<br/>"
                + "NOTE: If 'row' is outside the bounds of the results, or 'col' is not a valid column name,"
                + " then this will put '-1' on the stack.<br/>"
                + "NOTE1: If the returned value is an int, then this will put the value of the int and '0' on the stack.<br/>"
                + "NOTE2: If the returned value is a string, then this will put the 'address' and the 'length' of the"
                + " string, and '1' on the stack.<br/>"
                + "Example usage: myCol 4 GETROWDATA$";
            StackEffect = "( col row -- -1 ) or " +
                          "( col row -- value 0 ) or " +
                          "( col row -- c-addr length 1 )";
        }

        public override void Call()
        {
            int row = Stack.Pop();
            int a0 = Stack.Pop();               // address of Column Name
            int n0 = Forth.Ram.GetInt(a0 + 8);  // curlen of Column Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("getRowData", row, s0);
        }
    }
}
