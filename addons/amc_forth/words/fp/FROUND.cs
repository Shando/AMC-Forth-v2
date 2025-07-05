using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FROUND : Words
    {
        public FROUND(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FROUND";
            Description = "Return 'f' rounded to the nearest integral value using 'round to nearest' rule.</br>"
                + "Example usage: 15.66 FROUND";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();
            double f1 = Math.Round((double)f);
            f = (float)f1;
            Stack.FPPush(f);
        }
    }
}
