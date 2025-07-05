using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FStar : Words
    {
        public FStar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F*";
            Description = "Multiply 'f1' by 'f2' returning the product 'f3'.</br>"
                + "NOTE: An error occurs if 'f3' is outside the bounds of a float. This pushes 0.0 onto Floating Point stack.</br>"
                + "Example usage: 0.25 6.5 F*";
            StackEffect = "( f1 f2 -- f3 )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();
            double f3 = f1 * f2;

            if (f3 > float.MaxValue || f3 < float.MinValue)
            {
                Forth.Util.RprintError("Floating Point Error: Result out of bounds.");
                Stack.FPPush(0.0f);
            }
            else
            {
                Stack.FPPush((float)f3);
            }
        }
    }
}
