using Godot;
using System;
using System.Threading;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class GetPixel : Words
    {
         public GetPixel(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETPIXEL";
            Description =
                "Gets the colour ('r', 'g', 'b', 'a') of the pixel 'x', 'y'.<br/>"
                + "Example usage: 50 50 GETPIXEL";
            StackEffect = "( x y -- r g b a )";
        }

        public override void Call()
        {
            int y = (int)Stack.Pop();
            int x = (int)Stack.Pop();

            GodotThread.SetThreadSafetyChecksEnabled(false);
            Color c = Forth.fg.GetViewport().GetTexture().GetImage().GetPixel(x, y);
            GodotThread.SetThreadSafetyChecksEnabled(true);
            Stack.Push((int)(Math.Round(c.R, 3, MidpointRounding.AwayFromZero) * 255));
            Stack.Push((int)(Math.Round(c.G, 3, MidpointRounding.AwayFromZero) * 255));
            Stack.Push((int)(Math.Round(c.B, 3, MidpointRounding.AwayFromZero) * 255));
            Stack.Push((int)(Math.Round(c.A, 3, MidpointRounding.AwayFromZero) * 255));
        }
    }
}
