using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class CellPlus : Words
    {
        public CellPlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CELL+";
            Description = "Add the size in bytes of a cell to a_addr1, returning a_addr2.";
            StackEffect = "( a-addr1 -- a-addr2 )";
        }

        public override void Call()
        {
            Stack.Push(RAM.CellSize);
            Forth.CoreWords.Plus.Call();
        }
    }
}
