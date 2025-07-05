using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FToI : Words
    {
        public FToI(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F>I";
            Description = "Return the equivalent of the integer portion of 'f'.</br>"
                + "NOTE1: The fractional portion of 'f' is discarded.</br>"
                + "NOTE2: Rounding the floating point value prior to calling F>I is advised, as F>I rounds towards zero.</br>"
                + "Example usage: 25.25 F>I";
            StackEffect = "( f -- n )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();
            f = MathF.Round(f, 0, MidpointRounding.ToZero);
            Stack.FPPush(f);
        }
    }
}
