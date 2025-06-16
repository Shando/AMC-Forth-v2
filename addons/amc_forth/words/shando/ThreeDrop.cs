using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class ThreeDrop : Words
    {
        public ThreeDrop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "3DROP";
            Description = "Remove the top three items from the stack."
                + " Example usage: 5 6 7 3DROP";
            StackEffect = "( x1 x2 x3 -- )";
        }

        public override void Call()
        {
            Stack.Pop();
            Stack.Pop();
            Stack.Pop();
        }
    }
}
