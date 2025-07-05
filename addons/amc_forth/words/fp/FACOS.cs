using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FACOS : Words
    {
        public FACOS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FACOS";
            Description = "Return the principal radian angle whose cosine is 'f'.<br/>"
                + "NOTE1: If abs('f') is greater than 1 this will push 0.0 onto the Floating Point stack.<br/>"
                + "NOTE2: You can use RAD2DEG to convert radians to degrees.</br>"
                + "Example usage: 0.25 FACOS";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();

            if (MathF.Abs(f) > 1)
            {
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush(MathF.Acos(f));
            }
        }
    }
}
