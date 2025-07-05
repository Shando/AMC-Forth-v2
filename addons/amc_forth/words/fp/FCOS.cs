using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FCOS : Words
    {
        public FCOS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FCOS";
            Description = "Return the cosine of the radian angle 'f'.</br>"
                + "Example usage: 0.25 FCOS";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(MathF.Cos(f));
        }
    }
}
