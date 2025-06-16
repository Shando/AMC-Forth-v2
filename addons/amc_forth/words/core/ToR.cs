using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class ToR : Words
    {
        public ToR(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = ">R";
            Description =
                "Remove the item on top of the data stack and put it on the return stack.";
            StackEffect = "(S: x -- ) (R: -- x )";
        }

        public override void Call()
        {
            Stack.RPush(Stack.Pop());
        }
    }
}
