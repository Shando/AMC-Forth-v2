using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FTANH : Words
    {
        public FTANH(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FTANH";
            Description = "Return the hyperbolic tangent of the radian angle 'f'.</br>"
                + "Example usage: 0.25 FTANH";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Tanh(f));
        }
    }
}
