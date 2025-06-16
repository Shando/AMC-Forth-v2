using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class FourDrop : Words
    {
        public FourDrop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "4DROP";
            Description = "Remove the top four items from the stack."
                + " Example usage: 5 6 7 8 4DROP";
            StackEffect = "( x1 x2 x3 x4 -- )";
        }

        public override void Call()
        {
            Stack.Pop();
            Stack.Pop();
            Stack.Pop();
            Stack.Pop();
        }
    }
}
