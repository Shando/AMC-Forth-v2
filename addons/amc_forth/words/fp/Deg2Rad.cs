using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class Deg2Rad : Words
    {
        public Deg2Rad(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DEG2RAD";
            Description = "Converts the top value on the Floating Point stack from degrees to radians.</br>"
                + "Example usage: 166.66 DEG2RAD";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            Stack.FPPush((float)(Stack.FPPop() * (Math.PI / 180.0)));
        }
    }
}
