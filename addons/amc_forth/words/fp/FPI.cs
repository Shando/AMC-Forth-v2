using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FPI : Words
    {
        public FPI(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FPI";
            Description = "Push PI onto the Floating Point stack.</br>"
                + "Example usage: FPI";
            StackEffect = "( -- PI )";
        }

        public override void Call()
        {
            Stack.FPPush(MathF.PI);
        }
    }
}
