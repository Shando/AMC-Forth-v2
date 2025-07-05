using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FStarStar : Words
    {
        public FStarStar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F**";
            Description = "Raise 'f1' to the power 'f2' returning the product 'f3'.</br>"
                + "NOTE: An error occurs if 'f3' is outside the bounds of a float. This pushes 0.0 onto Floating Point stack.</br>"
                + "Example usage: 25.5 2.0 F**";
            StackEffect = "( f1 f2 -- f3 )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();
            double f3 = Math.Pow(f1, f2);

            if (f3 > float.MaxValue || f3 < float.MinValue)
            {
                Forth.Util.RprintError("Floating Point Error: Result out of bounds.");
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush((float)f3);
            }
        }
    }
}
