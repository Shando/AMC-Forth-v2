using Godot;
using System.Text;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FStoreDollar : Words
    {
        public FStoreDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FSTORE$";
            Description =
                "Populate the string variable 'var$' with the string representation of the Floating Point number stored on the top of the Floating Point stack.<br/>"
                + "NOTE: 'var$' must have already been initialised with SET$ before you use this word.<br/>"
                + "NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>"
                + "Example usage: var$ FSTORE$";
            StackEffect = "( var$ -- )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            var tStr = f.ToString();
            byte[] bytes = Encoding.ASCII.GetBytes(tStr);

            for (int i = 0; i < bytes.Length; i++) // just copy it at the end of the dictionary as a temporary area
            {
                Forth.Ram.SetByte(Forth.DictTopP + i, bytes[i]);
            }

            Stack.Push(Forth.DictTopP);
            Stack.Push(tStr.Length);

            Forth.ShandoWords.DashRot.Call();
            Forth.ShandoWords.DashRot.Call();
            Forth.ShandoWords.SetDollar.Call();
        }
    }
}
