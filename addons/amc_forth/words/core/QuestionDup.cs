using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class QuestionDup : Words
    {
        public QuestionDup(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "?DUP";
            Description =
                "Conditionally duplicate the top item on the stack if its value is " + "non-zero.";
            StackEffect = "( x -- x | x x )";
        }

        public override void Call()
        {
            var n = Stack.DataStack[Stack.DsP];

            if (n != 0)
            {
                Stack.Push(n);
            }
        }
    }
}
