using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class DrawString : Words
    {
        public DrawString(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DRAWSTRING";
            Description =
                "Draws the string of characters of length ('l'), denoted by their ASCII codes, with a foreground colour ('r', 'g', 'b', 'a'),"
                + " starting at the pixel location stored using AT-XYG.<br/>"
                + "A background colour ('rb', 'gb', 'bb', 'ab') and size ('s') can also be specified.<br/>"
                + "'s' is a multiple of 20, and must be in the range 1 - 4 (any number less than 1 will be replaced with 1 and,"
                + " any number greater than 4 will be replaced with 4).<br/>"
                + "NOTE: If s = 1 then each character will be 20 x 20 pixels."
                + "Example usage: 0 0 AT-XY 65 66 67 68 69 70 6 1 255 0 0 255 0 0 0 DRAWSTRING";
            StackEffect = "( [SEQUENCE OF CHARS] l s r g b a rb gb bb ab -- )";
        }

        public override void Call()
        {
            float ab = Stack.Pop();
            float bb = Stack.Pop();
            float gb = Stack.Pop();
            float rb = Stack.Pop();
            float a = Stack.Pop();
            float b = Stack.Pop();
            float g = Stack.Pop();
            float r = Stack.Pop();
            int s = Stack.Pop();
            int l = Stack.Pop();

            int[] text = new int[l];

            for (int z = l - 1; z > -1; z--)
            {
                text[z] = Stack.Pop();
            }

            Vector2 pos = new(Forth.AtXYG[0] * 20, Forth.AtXYG[1] * 20);
            Color cb = new(rb / 255.0f, gb / 255.0f, bb / 255.0f, ab / 255.0f);
            Color cf = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

            Forth.fg.CallDeferred("addString", cb, pos, cf, text, s);
        }
    }
}
