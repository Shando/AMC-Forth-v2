using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FTau : Words
    {
        public FTau(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FTAU";
            Description = "Push Tau, the number of radians in one turn, onto the Floating Point stack.</br>"
                + "Example usage: FTAU";
            StackEffect = "( -- Tau )";
        }

        public override void Call()
        {
            Stack.FPPush(MathF.Tau);
        }
    }
}
