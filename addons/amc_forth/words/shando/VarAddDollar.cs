using Forth.Core;
using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class VarAddDollar : Words
    {
        public VarAddDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "VARADD$";
            Description = "Adds the string variable 'var2$' to the string variable 'var1$'.<br/>"
                + "NOTE: 'var1$' and 'var2$' must have already been initialised with SET$ before you use this word.<br/>"
                + "NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>"
                + "Example usage: myString2 myString1 ADD$.";
            StackEffect = "( var2$ var1$ -- )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8);
            var maxlen = Forth.Ram.GetInt(addr + 4);
            var newaddr = Stack.Pop();
            var newlen = Forth.Ram.GetInt(newaddr + 8);

            if (newlen + curlen > maxlen)
            {
                newlen = maxlen - curlen;
            }

            Forth.Ram.SetInt(addr + 8, curlen + newlen);

            Stack.Push(newaddr + 12);
            Stack.Push(addr + 12 + curlen);
            Stack.Push(newlen);
            Forth.CoreWords.Move.Call();
        }
    }
}