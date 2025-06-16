using System;
using Godot;

namespace Forth.CommonUse
{
    [GlobalClass]
    public partial class MSlash : Words
    {
        public MSlash(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "M/";
            Description = "Divide d by n1 leaving the single precision quotient n2.";
            StackEffect = "( d n1 -- n2 )";
            PreVal = 3;
            PostVal = 1;
        }

        public override void Call()
        {
            var n = Stack.Pop();
            Stack.Push(Convert.ToInt32((Stack.PopDint() / n) & UInt32.MaxValue));
        }
    }
}
