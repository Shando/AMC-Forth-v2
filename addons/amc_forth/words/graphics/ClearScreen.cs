using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ClearScreen : Words
    {
        public ClearScreen(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CLEARSCREEN";
            Description = 
                "Fills the foreground screen with colour ('r', 'g', 'b', 'a')."
                + " NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON"
                + " Example usage: 255 255 0 255 1 CLEARSCREEN";
            StackEffect = "( r g b a aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float a = Stack.Pop();
            float b = Stack.Pop();
            float g = Stack.Pop();
            float r = Stack.Pop();

            Color c = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

            Forth.fg.CallDeferred("addCLS", c, aa);
        }
    }
}
