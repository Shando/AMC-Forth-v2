using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class True : Words
    {
        public True(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "TRUE";
            Description = "Return a true value, a single-cell value with all bits set.";
            StackEffect = "( -- flag )";
        }

        public override void Call()
        {
            Stack.Push(AMCForth.True);
        }
    }
}
