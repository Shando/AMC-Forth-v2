using Godot;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckOpenDb : Words
    {
        public DuckOpenDb(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKOPENDB";
            Description =
                "Opens the database, 'db' (a string created using S\").<br/>"
                + "NOTE: The database can be opened in Read Only mode by setting 'ro' to 0, otherwise, set to 1 for Read and Write access.<br/>"
                + "NOTE1: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>"
                + "Example usage: S\" myDB\" 1 DUCKOPENDB";
            StackEffect = "( db ro -- flag )";
        }

        public override void Call()
        {
            int ro = Stack.Pop();
            int n0 = Stack.Pop();   // Length of Database Name
            int a0 = Stack.Pop();   // Address of Database Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Words.bRunning = true;
            Forth.bg.CallDeferred("openDb", s0, ro);
        }
    }
}
