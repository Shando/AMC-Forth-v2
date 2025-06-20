using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class DrawRectangle : Words
    {
        public DrawRectangle(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DRAWRECTANGLE";
            Description = 
                "Draws a rectangle starting at pixel ('x', 'y'), with width ('w1'), height ('h1'), line width ('lw') and"
                + " fill colour ('r1', 'g1', 'b1', 'a1')."
                + " This also draws a second rectangle outside the first with line width ('bw'), and fill colour ('r2', 'g2', 'b2', 'a2').<br/>"
                + "NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON.<br/>"
                + "Example usage: 100 100 10 10 5 0 255 0 255 0 0 0 0 0 1 DRAWRECTANGLE";
            StackEffect = "( x y w h lw r1 g1 b1 a1 bw r2 g2 b2 a2 aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float a2 = Stack.Pop();
            float b2 = Stack.Pop();
            float g2 = Stack.Pop();
            float r2 = Stack.Pop();
            float bw = Stack.Pop();
            float a1 = Stack.Pop();
            float b1 = Stack.Pop();
            float g1 = Stack.Pop();
            float r1 = Stack.Pop();
            float lw = Stack.Pop();
            float h = Stack.Pop();
            float w = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();

            Color c2 = new(r2 / 255.0f, g2 / 255.0f, b2 / 255.0f, a2 / 255.0f);
            Vector2 pos1 = new(x - bw, y - bw);
            Vector2 size1 = new(w + bw * 2 + lw / 2, h + bw * 2 + lw / 2);
            Rect2 rect2 = new(pos1, size1);

            Color c1 = new(r1 / 255.0f, g1 / 255.0f, b1 / 255.0f, a1 / 255.0f);
            Vector2 pos2 = new(x, y);
            Vector2 size2 = new(w, h);

            if (bw > 0)
            {
                if (bw % 2 != 0)
                {
                    pos2.X += 0.5f;
                    pos2.Y += 0.5f;
                }
            }

            Rect2 rect1 = new(pos2, size2);

            Forth.fg.CallDeferred("addRect", rect1, lw, c1, rect2, bw, c2, aa);
        }
    }
}
