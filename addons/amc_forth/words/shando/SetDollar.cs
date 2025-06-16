using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class SetDollar : Words
    {
        public SetDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SET$";
            Description = "Stores the string denoted by 'addr' (address) and 'len' (length) in string variable 'var$'."
                + " NOTE: This will overwrite the existing string in 'var$', but may leave some characters if 'len' is less than"
                + "     the current length of the stored string."
                + " NOTE2: A string that doesn't fit in the buffer has any overflow characters discarded."
                + " Example usage: S\" My String\" myVar SET$";
            StackEffect = "( addr len var$ -- )";
        }

        public override void Call()
        {
            Forth.CoreWords.Dup.Call();
            Stack.Push(4);
            Forth.CoreWords.Plus.Call();
            Forth.CoreWords.Dup.Call();
            var addr = Stack.Pop();
            Forth.Ram.SetInt(addr - 4, addr + 8);
            Forth.CoreWords.Fetch.Call();
            Forth.CoreWords.ToR.Call();         // put TOS into R
            Forth.CoreWords.Swap.Call();        // NEW
            Forth.CoreWords.RFrom.Call();       // NEW
            Forth.CoreWords.Min.Call();         // get minimum of top 2 items on stack
            var curlen = Stack.Pop();
            Stack.Push(curlen);
            Forth.CoreWords.Swap.Call();
            Stack.Push(12);
            Forth.CoreWords.Plus.Call();
            Forth.CoreWords.Swap.Call();
            Forth.CoreWords.Move.Call();
            Forth.Ram.SetInt(addr + 4, curlen);
        }
    }
}