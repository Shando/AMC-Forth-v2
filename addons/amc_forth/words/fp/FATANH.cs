using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FATANH : Words
    {
        public FATANH(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FATANH";
            Description = "Return the floating point value whose hyperbolic tangent value is 'f'.<br/>"
                + "NOTE: If 'f' is outside the range -1E10 to 1E10 this will return 0.0.</br>"
                + "Example usage: 0.25 FATANH";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();

            if (f < -1e10f || f > 1e10f)
            {
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush(MathF.Atanh(f));
            }
        }
    }
}
