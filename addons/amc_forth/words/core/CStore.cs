using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class CStore : Words
    {
        public CStore(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "C!";
            Description =
                "Store the low-order character of the second stack item at c-addr, "
                + "removing both from the stack.";
            StackEffect = "( c c-addr -- )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            Forth.Ram.SetByte(addr, Stack.Pop());
        }
    }
}
