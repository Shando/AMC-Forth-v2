using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ClearScreenPartial : Words
    {
        public ClearScreenPartial(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CLEARSCREENPARTIAL";
            Description = 
                "Fills the area of the foreground screen denoted by the starting pixel ('x', 'y'), the width ('w') and the height ('h')"
                + " with colour ('r', 'g', 'b', 'a').<br/>"
                + "NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON.<br/>"
                + "Example usage: 0 0 400 240 0 0 0 255 1 CLEARSCREENPARTIAL";
            StackEffect = "( x y w h r g b a aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float a = Stack.Pop();
            float b = Stack.Pop();
            float g = Stack.Pop();
            float r = Stack.Pop();
            float h = Stack.Pop();
            float w = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();

            Rect2 clearScreenRect = new(x, y, w, h);
            Color c = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

            Forth.fg.CallDeferred("addCLSP", clearScreenRect, c, aa);
        }
    }
}
