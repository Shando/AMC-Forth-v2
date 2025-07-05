using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class Rad2Deg : Words
    {
        public Rad2Deg(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "RAD2DEG";
            Description = "Converts the top value on the Floating Point stack from radians to degrees.<br/>"
                + "Example usage: 15 RAD2DEG";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            Stack.FPPush((float)(Stack.FPPop() * (180.0 / Math.PI)));
        }
    }
}
