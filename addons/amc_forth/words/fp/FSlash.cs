using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSlash : Words
    {
        public FSlash(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F/";
            Description = "Divide 'f1' by 'f2' returning the quotient 'f3'.</br>"
                + "NOTE: An error occurs if 'f2' equals zero and pushes 0.0 onto Floating Point stack.</br>"
                + "Example usage: 15.5 0.25 F/";
            StackEffect = "( f1 f2 -- f3 )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();

            if (f2 == 0.0f)
            {
                Forth.Util.RprintError("Floating Point Error: Divisor cannot be zero.");
                Stack.FPPush(0.0f);
            }
            else
            {
                float f3 = f1 / f2;
                Stack.FPPush(f3);
            }
        }
    }
}
