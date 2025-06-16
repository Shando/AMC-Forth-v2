using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class GreaterThan : Words
    {
        public GreaterThan(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = ">";
            Description = "Return true if and only if n1 is greater than n2";
            StackEffect = "( n1 n2 -- flag )";
        }

        public override void Call()
        {
            var t = Stack.Pop();

            if (t < Stack.Pop())
            {
                Stack.Push(AMCForth.True);
            }
            else
            {
                Stack.Push(AMCForth.False);
            }
        }
    }
}
