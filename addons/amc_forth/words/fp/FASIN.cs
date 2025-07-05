using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FASIN : Words
    {
        public FASIN(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FASIN";
            Description = "Return the principal radian angle whose sine is 'f'.<br/>"
                + "NOTE1: If abs('f') is greater than 1 this pushes 0.0 onto the Floating Poiunt stack.<br/>"
                + "NOTE2: You can use RAD2DEG to convert radians to degrees.</br>"
                + "Example usage: 0.25 FASIN";
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
                Stack.FPPush(MathF.Asin(f));
            }
        }
    }
}
