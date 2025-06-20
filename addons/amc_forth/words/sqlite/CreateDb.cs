using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class CreateDb : Words
    {
        public CreateDb(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CREATEDB";
            Description =
                "Creates a database, 'db' (a string created using S\").<br/>"
                + "NOTE: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation,"
                + " and leaves the database open.<br/>"
                + "Example usage: S\" myDB\" CREATEDB";
            StackEffect = "( db -- flag )";
        }

        public override void Call()
        {
            int n0 = Stack.Pop();   // Length of Database Name
            int a0 = Stack.Pop();   // Address of Database Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("createDb", s0);
        }
    }
}
