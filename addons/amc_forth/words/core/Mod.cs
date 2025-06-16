using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Mod : Words
    {
        public Mod(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "MOD";
            Description = "Divide n1 by n2, giving the remainder n3.";
            StackEffect = "(n1 n2 -- n3 )";
        }

        public override void Call()
        {
            var n2 = Stack.Pop();
            Stack.Push(Stack.Pop() % n2);
        }
    }
}
