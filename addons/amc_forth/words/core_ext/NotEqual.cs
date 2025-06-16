using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class NotEqual : Words
    {
        public NotEqual(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "<>";
            Description = "Return true if and only if n1 is not equal to n2.";
            StackEffect = "( n1 n2 -- flag )";
        }

        public override void Call()
        {
            var t = Stack.Pop();

            if (t != Stack.Pop())
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
