using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class TwoTuck : Words
    {
        public TwoTuck(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "2TUCK";
            Description = "Place a copy of the two top stack items below the fourth stack item."
                + " Example usage: 5 6 7 8 2TUCK";
            StackEffect = "( x1 x2 x3 x4 -- x3 x4 x1 x2 x3 x4 )";
        }

        public override void Call()
        {
            var x4 = Stack.Pop();
            var x3 = Stack.Pop();
            var x2 = Stack.Pop();
            var x1 = Stack.Pop();
            Stack.Push(x3);
            Stack.Push(x4);
            Stack.Push(x1);
            Stack.Push(x2);
            Stack.Push(x3);
            Stack.Push(x4);
        }
    }
}
