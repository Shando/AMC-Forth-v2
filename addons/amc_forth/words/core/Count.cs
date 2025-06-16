using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Count : Words
    {
        public Count(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "COUNT";
            Description =
                "Return the length, u, and address of the text portion of a counted string.";
            StackEffect = "( c_addr1 -- c_addr2 u )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            Stack.Push(addr + 1);
            Stack.Push(Forth.Ram.GetByte(addr));
        }
    }
}
