using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Drop : Words
    {
        public Drop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DROP";
            Description = "Drop (remove) the top entry of the stack.";
            StackEffect = "( x -- )";
        }

        public override void Call()
        {
            Stack.Pop();
        }
    }
}
