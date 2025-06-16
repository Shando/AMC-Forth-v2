using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class OpenDbDollar : Words
    {
        public OpenDbDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "OPENDB$";
            Description =
                "Opens the database, 'db' (a string variable)."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: myDB OPENDB$";
            StackEffect = "( db -- flag )";
        }

        public override void Call()
        {
            int a0 = Stack.Pop();                // address of Database Name
            int n0 = Forth.Ram.GetInt(a0 + 8);   // curlen of Database Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Forth.bg.CallDeferred("openDb", s0);
        }
    }
}
