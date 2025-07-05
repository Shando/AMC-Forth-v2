using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FPlus : Words
    {
        public FPlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F+";
            Description = "Add 'f2' to 'f1' returning 'f3'.</br>"
                + "NOTE: An error occurs if the sum is greater than the maximum value for a float. This pushes 0.0 onto the Floating Point stack.</br>"
                + "Example usage: 0.25 6.75 F+";
            StackEffect = "( f1 f2 -- f3 )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();
            double d = (double)f1 + (double)f2;

            if (d > float.MaxValue || d < float.MinValue)
            {
                Forth.Util.RprintError("Floating Point Error: Result out of bounds.");
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush((float)d);
            }
        }
    }
}
