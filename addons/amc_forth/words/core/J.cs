using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class J : Words
    {
        public J(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "J";
            Description = "Push a copy of the next-outer DO-LOOP index value to the stack.";
            StackEffect = "( -- n )";
        }

        public override void Call()
        {
            // reach up into the return stack for the value
            Stack.Push(Stack.ReturnStack[Stack.RsP + 2]);
        }
    }
}
