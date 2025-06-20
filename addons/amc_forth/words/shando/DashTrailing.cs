using Forth.Core;
using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class DashTrailing : Words
    {
        public DashTrailing(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "-TRAILING";
            Description =
                "If 'u1' is greater than zero, 'u2' is equal to 'u1' less the number of spaces at the end of the character string specified by 'c-addr' 'u1'.<br/>"
                + "NOTE: If 'u1' is zero or the entire string consists of spaces, 'u2' is zero.<br/>"
                + "Example usage: myVar 5 -TRAILING";
            StackEffect = "( c-addr u1 -- c-addr u2 )";
        }

        public override void Call()
        {
            //BEGIN DUP WHILE 2DUP + 1- C@ BL = WHILE 1- REPEAT THEN
            Forth.CoreWords.Begin.Call();
            Stack.Push(Stack.DataStack[Stack.DsP]);
            Forth.CoreWords.While.Call();
            Forth.CoreWords.TwoDup.Call();
            Stack.Push(Stack.Pop() + Stack.Pop());
            Stack.Push(Stack.Pop() - 1);
            Stack.Push(Forth.Ram.GetByte(Stack.Pop()));
            Stack.Push(Terminal.BL.ToAsciiBuffer()[0]);
            Forth.CoreWords.Equal.Call();
            Forth.CoreWords.While.Call();
            Stack.Push(Stack.Pop() - 1);
            Forth.CoreWords.Repeat.Call();
            Forth.CoreWords.Then.Call();
        }
    }
}
