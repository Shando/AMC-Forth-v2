using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Minus : Words
    {
        public Minus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "-";
            Description = "Subtract n2 from n1, leaving the difference n3.";
            StackEffect = "( n1 n2 -- n3 )";
        }

        public override void Call()
        {
            var n = Stack.Pop();
            Stack.Push(Stack.Pop() - n);
        }
    }
}
