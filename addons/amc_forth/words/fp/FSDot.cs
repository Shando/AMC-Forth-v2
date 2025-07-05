using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSDot : Words
    {
        public FSDot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FS.";
            Description = "Display, in the console, the top number on the floating-point stack using scientific notation <significand><exponent>,"
                + " where <significand> := [-]<digit>.<digits0> and <exponent> := E[-]<digits>.<br/>"
                + "NOTE1: This displays with a trailing space automatically.<br/>"
                + "NOTE2: An error occurs if the value of BASE is not (decimal) ten. This will leave the stack as is.<br/>"
                + "Example usage: 123456789.123 FS.";
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
                string s = d.ToScientificNotation(Forth.precision);
                Forth.Util.PrintTerm(s + " ");
            }
        }
    }
}
