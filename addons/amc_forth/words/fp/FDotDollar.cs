using Godot;
using System.Text;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FDotDollar : Words
    {
        public FDotDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F.$";
            Description = "Saves the top number on the floating-point stack to the denoted string variable 'var$' using fixed-point notation:"
                + " [-]<digits>.<digits>.<br/>"
                + "NOTE1: This displays with a trailing space automatically.<br/>"
                + "NOTE2: An error occurs if the value of BASE is not (decimal) ten. This will leave the stack as is.<br/>"
                + "NOTE3: 'var$' must have already been initialised with SET$ before you use this word.<br/>"
                + "NOTE4: This will overwrite the existing string in 'var$', but may leave some characters if the length of the Floating Point string is less than"
                + " the current length of the stored string.<br/>"
                + "NOTE5: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>"
                + "Example usage: 123456789.123 myVar F.$";
            StackEffect = "( f var$ -- )";
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
                string s = d.ToFixedPointNotation(Forth.precision);
                int len = s.Length;
                byte[] bytes = Encoding.ASCII.GetBytes(s);
                var addr = Stack.Pop();
                var curlen = Forth.Ram.GetInt(addr + 8);
                var maxlen = Forth.Ram.GetInt(addr + 4);

                if (len > maxlen)
                {
                    len = maxlen;
                }

                Forth.Ram.SetInt(addr + 8, len);

                for (int i = 0; i < len; i++)
                {
                    Forth.Ram.SetByte(addr + 12 + i, bytes[i]);
                }
            }
        }
    }
}
