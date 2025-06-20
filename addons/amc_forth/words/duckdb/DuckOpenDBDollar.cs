using Godot;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckOpenDbDollar : Words
    {
        public DuckOpenDbDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKOPENDB$";
            Description =
                "Opens the database, 'db' (a string variable).<br/>"
                + "NOTE: The database can be opened in Read Only mode by setting 'ro' to 0, otherwise, set to 1 for Read and Write access.<br/>"
                + "NOTE1: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>"
                + "Example usage: myDB 1 DUCKOPENDB$";
            StackEffect = "( db ro -- flag )";
        }

        public override void Call()
        {
            int ro = Stack.Pop();
            Forth.CoreWords.Fetch.Call();
            int a0 = Stack.Pop();                // address of Database Name
            int n0 = Forth.Ram.GetInt(a0 - 4);   // curlen of Database Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Words.bRunning = true;
            Forth.bg.CallDeferred("openDb", s0, ro);
        }
    }
}
