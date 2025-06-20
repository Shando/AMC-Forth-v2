using Forth.Core;
using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class SlashString : Words
    {
        public SlashString(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "/STRING";
            Description =
                "Adjust the character string at 'c-addr1' by 'n' characters. The resulting character string, specified by 'c-addr2' 'u2',"
                + " begins at 'c-addr1' plus 'n' characters and is 'u1' minus 'n' characters long.<br/>"
                + "Example usage: S\" Test String\" 5 /STRING";
            StackEffect = "( c-addr1 u1 n -- c-addr2 u2 )";
        }

        public override void Call()
        {
            //DUP >R - SWAP R> CHARS + SWAP
            Stack.Push(Stack.DataStack[Stack.DsP]);
            Stack.RPush(Stack.Pop());
            var n = Stack.Pop();
            Stack.Push(Stack.Pop() - n);
            (Stack.DataStack[Stack.DsP], Stack.DataStack[Stack.DsP + 1]) = (Stack.DataStack[Stack.DsP + 1], Stack.DataStack[Stack.DsP]);
            Stack.Push(Stack.RPop());
            Stack.Push(Stack.Pop() + Stack.Pop());
            (Stack.DataStack[Stack.DsP], Stack.DataStack[Stack.DsP + 1]) = (Stack.DataStack[Stack.DsP + 1], Stack.DataStack[Stack.DsP]);
        }
    }
}
