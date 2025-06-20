using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class DrawLine : Words
    {
        public DrawLine(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DRAWLINE";
            Description =
                "Draws a line from pixel ('x1', 'y1') to pixel ('x2', 'y2') with colour ('r', 'g', 'b', 'a') and width ('w').<br/>"
                + "NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON.<br/>"
                + "Example usage: 100 100 200 200 0 0 255 255 10 1 DRAWLINE";
            StackEffect = "( x1 y1 x2 y2 r g b a w aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float w = Stack.Pop();
            float a = Stack.Pop();
            float b = Stack.Pop();
            float g = Stack.Pop();
            float r = Stack.Pop();
            float y2 = Stack.Pop();
            float x2 = Stack.Pop();
            float y1 = Stack.Pop();
            float x1 = Stack.Pop();

            Vector2 x0 = new(x1, y1);
            Vector2 y0 = new(x2, y2);
            Color c = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

            Forth.fg.CallDeferred("addLine", x0, y0, c, w, aa);
        }
    }
}
