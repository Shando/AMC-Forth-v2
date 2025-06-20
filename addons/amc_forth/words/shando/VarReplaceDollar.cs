using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class VarReplaceDollar : Words
    {
        public VarReplaceDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "VARREPLACE$";
            Description = "Replaces the characters in string variable 'var1$' from position start using string variable 'var2$'."
                + " This will replace the characters in 'var1$', starting from character 6, with the contents of string variable 'var2$'.<br/>"
                + "NOTE: 'var1$' and 'var2$' must have already been initialised with SET$ before you use this word.<br/>"
                + "NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>"
                + "Example usage: myString2 6 myString1 VARREPLACE$.";
            StackEffect = "( var2$ start var$ -- )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8);
            var maxlen = Forth.Ram.GetInt(addr + 4);
            var start = Stack.Pop();
            var newaddr = Stack.Pop();
            var newlen = Forth.Ram.GetInt(newaddr + 8);

            if (start + newlen > maxlen)
            {
                newlen = maxlen - start;
                Forth.Ram.SetInt(addr + 8, maxlen);
            }
            else
            {
                Forth.Ram.SetInt(addr + 8, start + newlen);
            }

            int i = start - 1;
            
            for (int j = 0; j < newlen; j++)
            {
                var newchar = Forth.Ram.GetByte(newaddr + 12 + j);
                Forth.Ram.SetByte(addr + 12 + i, newchar);
                i++;
            }
        }
    }
}