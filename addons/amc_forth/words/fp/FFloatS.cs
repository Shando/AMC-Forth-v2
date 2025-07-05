using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FFloatS : Words
    {
        public FFloatS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FLOATS";
            Description = "Return the size, in address units, of 'n' floating point numbers.</br>"
                + "Example usage: 10 FLOATS";
            StackEffect = "(DS: n -- n )";
        }

        public override void Call()
        {
            int n = Stack.Pop();
            n *= RAM.DCellSize * 2;
            Stack.Push(n);
        }
    }
}
