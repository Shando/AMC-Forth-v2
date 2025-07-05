using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSINCOS : Words
    {
        public FSINCOS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FSINCOS";
            Description = "Return the sine and the cosine of the radian angle 'f'.</br>"
                + "Example usage: 0.25 FSINCOS";
            StackEffect = "( f -- f1 f2 )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Sin(f));
            Stack.FPPush(MathF.Cos(f));
        }
    }
}
