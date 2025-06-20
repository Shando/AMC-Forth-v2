using Godot;
using System;
using System.Linq;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class DrawStringDollar : Words
    {
        public DrawStringDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DRAWSTRING$";
            Description = 
                "Draws the contents of the string variable 'var$' with a foreground colour ('r', 'g', 'b', 'a'), starting at the pixel location stored using AT-XYG."
                + " A background colour ('rb', 'gb', 'bb', 'ab') and size ('si') can also be specified.<br/>"
                + "'si' is a multiple of 20, and must be in the range 1 - 4 (any number less than 1 will be replaced with 1 and,"
                + " any number greater than 4 will be replaced with 4).<br/>"
                + "If length ('l') = -1 then the whole string will be printed, irrespective of the value of start ('st')."
                + " If 'l' is any other number, then the number of characters starting from start ('st') will be drawn.<br/>"
                + "NOTE: string variables start at character 0.<br/>"
                + "NOTE2: if 'st' is greater than the current length of the string, then nothing will be drawn.<br/>"
                + "NOTE3: if 'st' + 'l' is greater than the current length of the string, then only those characters between 'st' and the"
                + " current length of the string will be drawn.<br/>"
                + "NOTE4: If si = 1 then each character will be 20 x 20 pixels in size.<br/>"
                + "Example usage: 0 0 AT-XYG myVar GET$ -1 0 1 255 0 0 255 0 0 0 255 DRAWSTRING$";
            StackEffect = "( var$ GET$ l st si r g b a rb gb bb ab -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float ab = Stack.Pop();
            float bb = Stack.Pop();
            float gb = Stack.Pop();
            float rb = Stack.Pop();
            float a = Stack.Pop();
            float b = Stack.Pop();
            float g = Stack.Pop();
            float r = Stack.Pop();
            int si = Stack.Pop();
            int st = Stack.Pop();
            int l = Stack.Pop();
            int n0 = Stack.Pop();       // curlen of string variable
            int a0 = Stack.Pop();       // address of string variable
            string s0 = "";

            if (st <= n0)
            {
                s0 = Forth.Util.StrFromAddrN(a0, n0);

                if (si < 1)
                    si = 1;
                else if (si > 4)
                    si = 4;

                if (l != -1)
                {
                    if (st < 0)
                        st = 0;

                    // PRINT STRING FROM s -> s + l, TAKING INTO ACCOUNT curlen
                    var tot = st + l;

                    if (tot > n0)
                    {
                        l = n0 - st;
                    }

                    s0 = s0.Substring(st, l);
                }

                int[] text = s0.Select(c => (int)c).ToArray();

                Color cb = new(rb / 255.0f, gb / 255.0f, bb / 255.0f, ab / 255.0f);
                Vector2 pos = new(Forth.AtXYG[0] * 20, Forth.AtXYG[1] * 20);
                Color cf = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

                Forth.fg.CallDeferred("addString", cb, pos, cf, text, si);
            }
        }
    }
}
