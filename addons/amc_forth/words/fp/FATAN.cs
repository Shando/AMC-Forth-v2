using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FATAN : Words
    {
        public FATAN(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FATAN";
            Description = "Return the principal radian angle whose tangent is 'f'.<br/>"
                + "NOTE: You can use RAD2DEG to convert radians to degrees.</br>"
                + "Example usage: 0.25 FATAN";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Atan(f));
        }
    }
}
