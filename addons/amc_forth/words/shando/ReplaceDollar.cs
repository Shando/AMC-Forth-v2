using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class ReplaceDollar : Words
    {
        public ReplaceDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "REPLACE$";
            Description = "Replaces the characters in string variable 'var$' from position start using the provided string.<br/>"
                + "NOTE: 'var$' must have already been initialised with SET$ before you use this word.<br/>"
                + "NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>"
                + "NOTE2: The replacement string must have been created using S\".<br/>"
                + "Example usage: S\" London\" 6 myVar REPLACE$.";
            StackEffect = "( addr u start var$ -- )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8);
            var maxlen = Forth.Ram.GetInt(addr + 4);
            var start = Stack.Pop();
            var stringlen = Stack.Pop();
            var stringaddr = Stack.Pop();

            if (start + stringlen > maxlen)
            {
                stringlen = maxlen - start;
                Forth.Ram.SetInt(addr + 8, maxlen);
            }
            else
            {
                Forth.Ram.SetInt(addr + 8, start + stringlen);
            }

            int i = start;
            
            for (int j = 0; j < stringlen; j++)
            {
                var newchar = Forth.Ram.GetByte(stringaddr + j);
                Forth.Ram.SetByte(addr + 12 + i, newchar);
                i++;
            }
        }
    }
}