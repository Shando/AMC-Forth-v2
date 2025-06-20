using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class TwoNip : Words
    {
        public TwoNip(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "2NIP";
            Description = "Drop the second cell pair on the stack.<br/>"
                + "Example usage: 5 6 7 8 2NIP";
            StackEffect = "( x1 x2 x3 x4 -- x3 x4 )";
        }

        public override void Call()
        {
            var x4 = Stack.Pop();
            var x3 = Stack.Pop();
            Stack.Pop();
            Stack.Pop();
            Stack.Push(x3);
            Stack.Push(x4);
        }
    }
}
