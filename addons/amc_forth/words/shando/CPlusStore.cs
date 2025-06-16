using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class CPlusStore : Words
    {
        public CPlusStore(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "C+!";
            Description = "Cell version of COUNT."
                + " Example usage: CHAR x 256 C+!";
            StackEffect = "( ch addr -- )";
        }

        public override void Call()
        {
            Forth.CoreWords.ToR.Call();
            Forth.CoreWords.RFetch.Call();
            Forth.CoreWords.CFetch.Call();
            Forth.CoreWords.Plus.Call();
            Forth.CoreWords.RFrom.Call();
            Forth.CoreWords.CStore.Call();
        }
    }
}