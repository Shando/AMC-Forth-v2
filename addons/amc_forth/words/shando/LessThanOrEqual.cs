using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class LessThanOrEqual : Words
    {
        public LessThanOrEqual(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "<=";
            Description = "Return 'TRUE' if and only if 'n1' is less than or equal to 'n2'."
                + " Example usage: 5 10 <=";
            StackEffect = "( n1 n2 -- flag )";
        }

        public override void Call()
        {
            var t = Stack.Pop();

            if (Stack.Pop() <= t)
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
