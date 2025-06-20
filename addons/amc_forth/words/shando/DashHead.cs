using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class DashHead : Words
    {
        public DashHead(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "-HEAD";
            Description = "Removes 'i' characters from the beginning of the string variable 'var$'.<br/>"
                + "Example usage: myVar 4 -HEAD.";
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
                for (int i = numchar; i < curlen; i++)
                {
                    var curbyte = Forth.Ram.GetByte(addr + 12 + i);
                    Forth.Ram.SetByte(addr + 12 + i - numchar, curbyte);
                    Forth.Ram.SetByte(addr + 12 + i, 32);
                }
            }

            Forth.Ram.SetInt(addr + 8, curlen - numchar);
        }
    }
}