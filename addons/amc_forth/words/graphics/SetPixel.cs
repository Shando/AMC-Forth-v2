using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class SetPixel : Words
    {
        public SetPixel(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SETPIXEL";
            Description =
                "Sets the pixel denoted by 'x', 'y' to the colour ('r', 'g', 'b', 'a').<br/>"
                + "Example usage: 50 100 255 0 0 255 SETPIXEL";
            StackEffect = "( x y r g b a -- )";
        }

        public override void Call()
        {
            float a = (float)Stack.Pop();
            float b = (float)Stack.Pop();
            float g = (float)Stack.Pop();
            float r = (float)Stack.Pop();
            float y = (float)Stack.Pop();
            float x = (float)Stack.Pop();

            Vector2[] pts = new Vector2[1];
            pts[0] = new Vector2(x, y);
            Vector2[] uvs = new Vector2[1];
            uvs[0] = new Vector2(0.5f, 0.5f);
            Color[] col = new Color[1];
            col[0] = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

            Forth.fg.CallDeferred("addSetPixel", pts, uvs, col);
        }
    }
}
