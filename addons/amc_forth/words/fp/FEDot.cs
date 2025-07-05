using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FEDot : Words
    {
        public FEDot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FE.";
            Description = "Display, in the console, the top number on the floating-point stack using engineering notation,"
                + " where the significand is greater than or equal to 1.0 and less than 1000.0 and the decimal exponent is a multiple of three.<br/>"
                + "NOTE1: This displays with a trailing space automatically.<br/>"
                + "NOTE2: An error occurs if the value of BASE is not (decimal) ten. This will leave the stack as is.<br/>"
                + "Example usage: 123456789.123 FE.";
            StackEffect = "( f -- )";
        }

        public override void Call()
        {
            int b = Map.Base;

            if (b != 10)
            {
                Forth.Util.RprintError("Floating Point Error: Base does not equal 10.");
            }
            else
            {
                double d = (double)Stack.FPPop();
                string s = d.ToEngineeringNotation(Forth.precision);
                Forth.Util.PrintTerm(s + " ");
            }
        }
    }
}
