using Godot;

namespace Forth.String
{
    [GlobalClass]
    public partial class CMove : Words
    {
        public CMove(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CMOVE";
            Description =
                "Copy u characters from addr1 to addr2. The copy proceeds from LOWER to HIGHER addresses.";
            StackEffect = "( addr1 addr2 u -- )";
        }

        public override void Call()
        {
            var u = Stack.Pop();
            var a2 = Stack.Pop();
            var a1 = Stack.Pop();
            var i = 0;

            // move in ascending order a1 -> a2, fast, then slow
            while (i < u)
            {
                if (u - i >= RAM.DCellSize)
                {
                    Forth.Ram.SetDword(a2 + i, Forth.Ram.GetDword(a1 + i));
                    i += RAM.DCellSize;
                }
                else
                {
                    Forth.Ram.SetByte(a2 + i, Forth.Ram.GetByte(a1 + i));
                    i += 1;
                }
            }
        }
    }
}
