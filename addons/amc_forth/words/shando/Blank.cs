using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Blank : Words
    {
        public Blank(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "BLANK";
            Description =
                "If 'u' is greater than zero, store the character value for space in 'u' consecutive character positions in RAM beginning at 'c-addr'."
                + " Example usage: 256 20 BLANK";
            StackEffect = "( c-addr u -- )";
        }

        public override void Call()
        {
            var u = Stack.Pop();
            var a1 = Stack.Pop();

            if (u > 0)
            {
                var b = Terminal.BL.ToAsciiBuffer()[0];

                for (int i = 0; i < u; i++)
                {
                    Forth.Ram.SetByte(a1 + i, b);
                }
            }
        }
    }
}
