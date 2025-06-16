using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Cells : Words
    {
        public Cells(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CELLS";
            Description = "Return n2, the size in bytes of n1 cells.";
            StackEffect = "( n1 -- n2 )";
        }

        public override void Call()
        {
            Stack.Push(RAM.CellSize);
            Forth.CoreWords.Star.Call();
        }
    }
}
