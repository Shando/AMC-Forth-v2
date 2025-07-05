using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSIN : Words
    {
        public FSIN(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FSIN";
            Description = "Return the sine of the radian angle 'f'.</br>"
                + "Example usage: 0.25 FSIN";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Sin(f));
        }
    }
}
