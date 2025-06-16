using Forth.Core;
using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class AddDollar : Words
    {
        public AddDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "ADD$";
            Description = "Adds the string denoted by 'addr' (address) and 'len' (length) to string variable 'var$'."
                + " NOTE: 'var$' must have already been initialised with SET$ before you use this word."
                + " NOTE2: A string that doesn't fit in the buffer has any overflow characters discarded."
                + " Example usage: S\" text\" name ADD$";
            StackEffect = "( addr len var$ -- )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8);
            var maxlen = Forth.Ram.GetInt(addr + 4);
            var newlen = Stack.Pop();
            var newaddr = Stack.Pop();

            if (newlen + curlen > maxlen)
            {
                newlen = maxlen - curlen;
            }

            Forth.Ram.SetInt(addr + 8, curlen + newlen);

            Stack.Push(newaddr);
            Stack.Push(addr + 12 + curlen);
            Stack.Push(newlen);
            Forth.CoreWords.Move.Call();
        }
    }
}