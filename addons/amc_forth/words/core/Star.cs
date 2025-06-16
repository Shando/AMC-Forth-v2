using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Star : Words
    {
        public Star(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "*";
            Description = "Multiply n1 by n2 leaving the product n3.";
            StackEffect = "( n1 n2 -- n3 )";
        }

        public override void Call()
        {
            Stack.Push(Stack.Pop() * Stack.Pop());
        }
    }
}
