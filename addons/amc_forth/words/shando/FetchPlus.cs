using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class FetchPlus : Words
    {
        public FetchPlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "@+";
            Description = "Adds the cell size (in bytes) to the memory location ('addr1'), and then gets the new address and the value in the original address."
                + " Example usage: 256 @+";
            StackEffect = "( addr1 -- addr2 x )";
        }

        public override void Call()
        {
            Forth.CoreWords.Dup.Call();
            Forth.CoreWords.CellPlus.Call();
            Forth.CoreWords.Swap.Call();
            Forth.CoreWords.Fetch.Call();
        }
    }
}