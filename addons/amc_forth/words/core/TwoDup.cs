using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class TwoDup : Words
    {
        public TwoDup(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "2DUP";
            Description = "Duplicate the top cell pair.";
            StackEffect = "(x1 x2 -- x1 x2 x1 x2 )";
        }

        public override void Call()
        {
            var x2 = Stack.DataStack[Stack.DsP];
            var x1 = Stack.DataStack[Stack.DsP + 1];
            Stack.Push(x1);
            Stack.Push(x2);
        }
    }
}
