using System;
using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Emit : Words
    {
        public Emit(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "EMIT";
            Description = "Output one character to the console from the least significant byte of the top item on stack.";
            StackEffect = "( b -- )";
        }

        public override void Call()
        {
            byte[] c = { Convert.ToByte(Stack.Pop() & 0x0ff) };
            Forth.Util.PrintTerm(System.Text.Encoding.ASCII.GetString(c));
        }
    }
}
