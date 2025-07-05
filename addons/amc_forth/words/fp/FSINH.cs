using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSINH : Words
    {
        public FSINH(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FSINH";
            Description = "Return the hyperbolic sine of the radian angle 'f'.</br>"
                + "Example usage: 0.25 FSINH";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Sinh(f));
        }
    }
}
