using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class DropTable : Words
    {
        public DropTable(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DROPTABLE";
            Description =
                "Drops the table, 'tbl' (a string created using S\"), from the currently opened database."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: S\" myTbl\" DROPTABLE";
            StackEffect = "( tbl -- flag )";
        }

        public override void Call()
        {
            int n0 = Stack.Pop();   // Length of Table Name
            int a0 = Stack.Pop();   // Address of Table Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("dropTable", s0);
        }
    }
}
