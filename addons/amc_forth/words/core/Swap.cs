using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Swap : Words
    {
        public Swap(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SWAP";
            Description = "Exchange the top two items on the stack.";
            StackEffect = "( x1 x2 -- x2 x1 )";
        }

        public override void Call()
        {
            (Stack.DataStack[Stack.DsP], Stack.DataStack[Stack.DsP + 1]) = (Stack.DataStack[Stack.DsP + 1], Stack.DataStack[Stack.DsP]);
        }
    }
}
