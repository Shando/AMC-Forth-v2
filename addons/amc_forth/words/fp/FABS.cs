using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FABS : Words
    {
        public FABS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FABS";
            Description = "Return the absolute value of the top item on the Floating Point stack.</br>"
                + "Example usage: -0.25 FABS";
            StackEffect = "( f -- +f )";
        }

        public override void Call()
        {
            Stack.FPStack[Stack.FPsP] = MathF.Abs(Stack.FPStack[Stack.FPsP]);
        }
    }
}
