using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class IncDollar : Words
    {
        public IncDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "INC$";
            Description = "Adds the character denoted by 'char' to string variable 'var$'."
                + " NOTE: 'var$' must have already been initialised with SET$ before you use this word."
                + " NOTE2: A string that doesn't fit in the buffer has any overflow characters discarded."
                + " Example usage: CHAR x myVar INC$";
            StackEffect = "( char var$ -- )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8) + 1;
            var maxlen = Forth.Ram.GetInt(addr + 4);
            var newchar = Stack.Pop();

            if (curlen <= maxlen)
            {
                Forth.Ram.SetInt(addr + 8, curlen);
                Forth.Ram.SetByte(addr + 12 + curlen - 1, newchar);
            }
        }
    }
}