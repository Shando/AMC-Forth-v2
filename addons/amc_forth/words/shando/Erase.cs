using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Erase : Words
    {
        public Erase(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "ERASE";
            Description =
                "If 'u' is greater than zero, clear all bits in each of 'u' consecutive address units of memory, beginning at 'addr'.<br/>"
                + "Example usage: 256 4 ERASE";
            StackEffect = "( addr u -- )";
        }

        public override void Call()
        {
            var a1 = Stack.DataStack[Stack.DsP + 1];
            var u = Stack.DataStack[Stack.DsP];

            if (u > 0)
            {
                for (int x = 1; x <= u; x++)
                {
                    Stack.DataStack[a1 + x] = 0;
                }
            }
        }
    }
}
