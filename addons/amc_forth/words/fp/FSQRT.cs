using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSQRT : Words
    {
        public FSQRT(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FSQRT";
            Description = "Return the square root of 'f'.</br>"
                + "Example usage: 16.0 FSQRT";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Sqrt(f));
        }
    }
}
