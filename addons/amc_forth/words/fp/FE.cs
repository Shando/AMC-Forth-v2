using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FE : Words
    {
        public FE(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FE";
            Description = "Push e, the natural logarithm base, onto the Floating Point stack.</br>"
                + "Example usage: FE";
            StackEffect = "( -- e )";
        }

        public override void Call()
        {
            Stack.FPPush(MathF.E);
        }
    }
}
