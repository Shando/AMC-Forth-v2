using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FCOSH : Words
    {
        public FCOSH(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FCOSH";
            Description = "Return the hyperbolic cosine of the radian angle 'f'.</br>"
                + "Example usage: 0.25 FCOSH";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Cosh(f));
        }
    }
}
