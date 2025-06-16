using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class CreateDbDollar : Words
    {
        public CreateDbDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CREATEDB$";
            Description =
                "Creates a database, 'db' (a string variable). Puts 'TRUE' or 'FALSE' on the stack, depending"
                + " on the success of the operation, and leaves the database open."
                + " Example usage: 4 VAR$ dbName S\" myDB\" dbName SET$ dbName CREATEDB$";
            StackEffect = "( db -- flag )";
        }

        public override void Call()
        {
            int a0 = Stack.Pop();                // address of string variable
            int n0 = Forth.Ram.GetInt(a0 + 8);   // curlen of string variable

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("createDb", s0);
        }
    }
}
