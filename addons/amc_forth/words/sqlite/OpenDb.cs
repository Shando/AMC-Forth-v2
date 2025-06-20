using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class OpenDb : Words
    {
        public OpenDb(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "OPENDB";
            Description =
                "Opens the database, 'db' (a string created using S\").<br/>"
                + "NOTE: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>"
                + "Example usage: S\" myDB\" OPENDB";
            StackEffect = "( db -- flag )";
        }

        public override void Call()
        {
            int n0 = Stack.Pop();   // Length of Database Name
            int a0 = Stack.Pop();   // Address of Database Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("openDb", s0);
        }
    }
}
