using Godot;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckCloseDb : Words
    {
        public DuckCloseDb(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKCLOSEDB";
            Description =
                "Closes the currently opened database."
                + " NOTE: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: DUCKCLOSEDB";
            StackEffect = "( -- flag )";
        }

        public override void Call()
        {
            Forth.bg.CallDeferred("closeDb");
            bRunning = true;
        }
    }
}
