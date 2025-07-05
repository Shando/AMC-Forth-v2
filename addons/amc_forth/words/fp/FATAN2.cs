using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FATAN2 : Words
    {
        public FATAN2(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FATAN2";
            Description = "Return the principal radian angle (between -PI and PI) whose tangent is 'f1' / 'f2'.<br/>"
                + "NOTE1: If 'f1' and 'f2' both equal 0.0 this pushes 0.0 onto the Floating Point stack.<br/>"
                + "NOTE2: You can use RAD2DEG to convert radians to degrees.</br>"
                + "Example usage: 0.33 2.0 FATAN2";
            StackEffect = "( f1 f2 -- f )";
        }

        public override void Call()
        {
            var f2 = Stack.FPPop();
            var f1 = Stack.FPPop();

            if (f1 == 0.0f && f2 == 0.0f)
            {
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush(MathF.Atan2(f2, f1));
            }
        }
    }
}
