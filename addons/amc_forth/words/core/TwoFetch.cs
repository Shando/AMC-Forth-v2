using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class TwoFetch : Words
    {
        public TwoFetch(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "2@";
            Description =
                "Push the cell pair x1 x2 at a-addr onto the top of the stack. The "
                + "combined action of 2! and 2@ will always preserve the stack order "
                + "of the cells.";
            StackEffect = "( a-addr -- x1 x2 )";
        }

        public override void Call()
        {
            var a = Stack.Pop();
            Stack.Push(Forth.Ram.GetInt(a + RAM.CellSize));
            Stack.Push(Forth.Ram.GetInt(a));
        }
    }
}
