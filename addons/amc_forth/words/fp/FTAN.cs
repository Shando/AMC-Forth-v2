using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FTAN : Words
    {
        public FTAN(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FTAN";
            Description = "Return the tangent of the radian angle 'f'.</br>"
                + "NOTE: If 'f' == 0.0 this will return 0.0.</br>"
                + "Example usage: 0.25 FTAN";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Tan(f));
        }
    }
}
