using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FTilde : Words
    {
        public FTilde(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F~";
            Description = "If 'f3' is positive: Return TRUE if the absolute value of 'f1' - 'f2' is less than 'f3', else return FALSE.</br>"
                + "If 'f3' is 0: Return TRUE if the 'f1' and 'f2' are exactly equal, else return FALSE.</br>"
                + "If 'f3' is negative: Return TRUE if the absolute value of 'f1' - 'f2' is less than 'f3' multiplied by the sum of the"
                + " absolute values of 'f1' and 'f2', else return FALSE.</br>"
                + "Example usage: 15.25 -6.75 0.0 F~";
            StackEffect = "(FP: f1 f2 f3 -- ) (DS: -- flag )";
        }

        public override void Call()
        {
            float f3 = Stack.FPPop();
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();

            if (f3 > 0.0f)
            {
                if (MathF.Abs(f1 - f2) < f3)
                {
                    Stack.Push(AMCForth.True);
                }
                else
                {
                    Stack.Push(AMCForth.False);
                }
            }
            else if (f3 == 0.0f)
            {
                if (f1 == f2)
                {
                    Stack.Push(AMCForth.True);
                }
                else
                {
                    Stack.Push(AMCForth.False);
                }
            }
            else
            {
                if (MathF.Abs(f1 - f2) < MathF.Abs(f3) * (MathF.Abs(f1) + MathF.Abs(f2)))
                {
                    Stack.Push(AMCForth.True);
                }
                else
                {
                    Stack.Push(AMCForth.False);
                }
            }
        }
    }
}
