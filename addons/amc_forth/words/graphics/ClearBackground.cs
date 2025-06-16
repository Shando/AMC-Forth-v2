using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ClearBackground : Words
    {
        public ClearBackground(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CLEARBACKGROUND";
            Description = 
                "Clears the background layer."
                + " Example usage: CLEARBACKGROUND";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Forth.bg.CallDeferred("addClearBG");
        }
    }
}
