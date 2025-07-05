using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FASINH : Words
    {
        public FASINH(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FASINH";
            Description = "Return the floating point value whose hyperbolic sine value is 'f'.</br>"
                + "Example usage: 0.25 FASINH";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Asinh(f));
        }
    }
}
