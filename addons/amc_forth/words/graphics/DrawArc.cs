using Godot;
using System;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class DrawArc : Words
    {
        public DrawArc(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DRAWARC";
            Description = 
                "Draws an arc of radius ('ra'), width ('w') and colour ('r', 'g', 'b', 'a') around pixel ('x', 'y'), with a start angle ('sa')"
                + " and end angle ('ea'), consisting of ('p') points.<br/>"
                + "NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON.<br/>"
                + "Example usage: 240 400 100 33 66 33 0 255 255 255 33 1 DRAWARC";
            StackEffect = "( x y ra sa ea p r g b a w aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float w = Stack.Pop();
            float a = Stack.Pop();
            float b = Stack.Pop();
            float g = Stack.Pop();
            float r = Stack.Pop();
            float p = Stack.Pop();
            float ea = (float)(Stack.Pop() * (Math.PI / 180.0));
            float sa = (float)(Stack.Pop() * (Math.PI / 180.0));
            float ra = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();

            Vector2 p1 = new(x, y);
            Color c = new(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);

            Forth.fg.CallDeferred("addArc", p1, ra, sa, ea, p, c, w, aa);
        }
    }
}
