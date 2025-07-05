using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FACOSH : Words
    {
        public FACOSH(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FACOSH";
            Description = "Return the floating point value whose hyperbolic cosine value is 'f'.<br/>"
                + "NOTE: If 'f' < 1 this will push 0.0 onto the Floating Point stack.</br>"
                + "Example usage: 1.25 FACOSH";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();

            if (f < 1.0f)
            {
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush(MathF.Acosh(f));
            }
        }
    }
}
