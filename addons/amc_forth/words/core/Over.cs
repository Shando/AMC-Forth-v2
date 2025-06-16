using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Over : Words
    {
        public Over(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "OVER";
            Description = "Place a copy of x1 on top of the stack.";
            StackEffect = "( x1 x2 -- x1 x2 x1 )";
        }

        public override void Call()
        {
            Stack.Push(Stack.DataStack[Stack.DsP + 1]);
        }
    }
}
