using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FEXP : Words
    {
        public FEXP(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FEXP";
            Description = "Return e raised to the power of 'f'.<br/>"
                + "NOTE: An error occurs if 'f1' is greater than the maximum value of a float. This pushes 0.0 onto the Floating Point stack.</br>"
                + "Example usage: 0.25 FEXP";
            StackEffect = "( f -- f1 )";
        }

        public override void Call()
        {
            double f = (double)Stack.FPPop();
            double d = Math.Exp(f);

            if (d > float.MaxValue || d < float.MinValue)
            {
                Forth.Util.RprintError("Floating Point Error: Result out of bounds.");
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush((float)d);
            }
        }
    }
}
