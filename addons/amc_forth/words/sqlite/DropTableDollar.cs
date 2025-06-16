using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class DropTableDollar : Words
    {
        public DropTableDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DROPTABLE$";
            Description =
                "Drops the table, 'tbl' (a string variable) from the currently opened database."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: myTbl DROPTABLE$";
            StackEffect = "( tbl -- flag )";
        }

        public override void Call()
        {
            int a0 = Stack.Pop();               // address of Table Name
            int n0 = Forth.Ram.GetInt(a0 + 8);  // curlen of Table Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("dropTable", s0);
        }
    }
}
