using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class CloseDb : Words
    {
        public CloseDb(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CLOSEDB";
            Description =
                "Closes the currently opened database."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: CLOSEDB";
            StackEffect = "( -- flag )";
        }

        public override void Call()
        {
            Forth.bg.CallDeferred("closeDb");
        }
    }
}
