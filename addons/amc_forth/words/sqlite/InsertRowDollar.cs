using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class InsertRowDollar : Words
    {
        public InsertRowDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "INSERTROW$";
            Description =
                "Inserts a row into the currently opened database table, 'tbl' (a string variable)."
                + " The dictionary, 'dict' (a string variable) must be created as per the below:"
                + " {'col1name': col1value, 'col2name': col2value, etc.}"
                + " It must match the relevant entries in the table that do not have a default value."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: myTable myDict INSERTROW$";
            StackEffect = "( tbl dict -- flag )";
        }

        public override void Call()
        {
            int a1 = Stack.Pop();               // address of Dictionary
            int n1 = Forth.Ram.GetInt(a1 + 8);  // curlen of Dictionary
            int a0 = Stack.Pop();               // address of Table Name
            int n0 = Forth.Ram.GetInt(a0 + 8);  // curlen of Table Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);
            string s1 = Forth.Util.StrFromAddrN(a1, n1);

            Forth.bg.CallDeferred("insertRow", s0, s1);
        }
    }
}
