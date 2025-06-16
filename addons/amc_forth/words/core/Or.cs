using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Or : Words
    {
        public Or(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "OR";
            Description = "Return x3, the bit-wise inclusive or of x1 with x2.";
            StackEffect = "( x1 x2 -- x3 )";
        }

        public override void Call()
        {
            Stack.Push(Stack.Pop() | Stack.Pop());
        }
    }
}
