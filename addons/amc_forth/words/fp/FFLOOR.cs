using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FFLOOR : Words
    {
        public FFLOOR(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FFLOOR";
            Description = "Return 'f' rounded to the nearest integral value using 'round toward negative infinity' rule.</br>"
                + "Example usage: 0.25 FFLOOR";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();
            double f1 = Math.Floor((double)f);
            f = (float)f1;
            Stack.FPPush(f);
        }
    }
}
