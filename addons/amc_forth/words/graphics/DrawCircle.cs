using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class DrawCircle : Words
    {
        public DrawCircle(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DRAWCIRCLE";
            Description =
                "Draws a circle of radius ('ra'), width ('w1') and colour ('r1', 'g1', 'b1', 'a1') around pixel ('x', 'y')."
                + " This will also draw a border of width ('w2') and colour ('r2', 'g2', 'b2', 'a2').<br/>"
                + "NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON.<br/>"
                + "Example usage: 240 400 100 10 255 255 0 255 5 255 0 0 255 1 DRAWCIRCLE";
            StackEffect = "( x y ra w1 r1 g1 b1 a1 w2 r2 g2 b2 a2 aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float a2 = Stack.Pop();
            float b2 = Stack.Pop();
            float g2 = Stack.Pop();
            float r2 = Stack.Pop();
            float w2 = Stack.Pop();
            float a1 = Stack.Pop();
            float b1 = Stack.Pop();
            float g1 = Stack.Pop();
            float r1 = Stack.Pop();
            float w1 = Stack.Pop();
            float ra = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();

            Vector2 p = new(x, y);
            Color c1 = new(r1 / 255.0f, g1 / 255.0f, b1 / 255.0f, a1 / 255.0f);
            Color c2 = new(r2 / 255.0f, g2 / 255.0f, b2 / 255.0f, a2 / 255.0f);

            Forth.fg.CallDeferred("addCirc", p, ra, w1, c1, w2, c2, aa);
        }
    }
}
