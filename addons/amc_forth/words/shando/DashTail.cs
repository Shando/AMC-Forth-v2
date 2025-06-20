using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class DashTail : Words
    {
        public DashTail(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "-TAIL";
            Description = "Removes 'i' characters from the end of the string variable 'var$'.<br/>"
                + "Example usage: myVar 4 -TAIL.";
            StackEffect = "( var$ i -- )";
        }

        public override void Call()
        {
            var numchar = Stack.Pop();
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8);
            var maxlen = Forth.Ram.GetInt(addr + 4);

            if (numchar > maxlen)
            {
                for (int i = 0; i < maxlen; i++)
                {
                    Forth.Ram.SetByte(addr + 12 + i, 32);
                }

                Forth.Ram.SetInt(addr + 8, 0);
            }
            else
            {
                for (int i = 0; i < numchar; i++)
                {
                    Forth.Ram.SetByte(addr + 12 + curlen - 1 + i, 32);
                }

                Forth.Ram.SetInt(addr + 8, curlen - numchar);
            }
        }
    }
}