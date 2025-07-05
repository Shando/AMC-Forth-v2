using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FALOG : Words
    {
        public FALOG(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FALOG";
            Description = "Return 10 raised to the power of 'f'.<br/>"
                + "NOTE: An error occurs if 'f1' is outside the bounds of a float. This pushes 0.0 onto Floating Point stack.</br>"
                + "Example usage: 1.25 FALOG";
            StackEffect = "( f -- f1 )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            double d = Math.Pow(10, f);

            if (d > float.MaxValue || d < float.MinValue)
            {
                Forth.Util.RprintError("Floating Point Error: Result out of bounds.");
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush(MathF.Pow(10, f));
            }
        }
    }
}
