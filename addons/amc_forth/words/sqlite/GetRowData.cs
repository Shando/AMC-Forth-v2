using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class GetRowData : Words
    {
        public GetRowData(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETROWDATA";
            Description =
                "Gets the data returned after calling SELECTROWS."
                + " Puts the value of 'col' (a string value representing the name of the column in the results,"
                + " which must have been created with S\"), and 'row' (an integer value starting at 0 for the"
                + " first row), from the returned dataset onto the stack."
                + " NOTE: If 'row' is outside the bounds of the results, or 'col' is not a valid column name,"
                + " then this will put '-1' on the stack."
                + " If the returned value is an int, then this will put the value of the int and '0' on the stack."
                + " If the returned value is a string, then this will put the 'address' and the 'length' of the"
                + " string, and '1' on the stack."
                + " Example usage: S\" myCol\" 4 GETROWDATA";
            StackEffect = "( col-addr col-length row -- -1 ) or " +
                          "( col-addr col-length row -- value 0 ) or " +
                          "( col-addr col-length row -- c-addr length 1 )";
        }

        public override void Call()
        {
            int row = Stack.Pop();
            int n0 = Stack.Pop();   // Length of Column Name
            int a0 = Stack.Pop();   // Address of Column Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("getRowData", row, s0);
        }
    }
}
