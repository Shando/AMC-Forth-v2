using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class Tuck : Words
    {
        public Tuck(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "TUCK";
            Description = "Place a copy of the top stack item below the second stack item.";
            StackEffect = "( x1 x2 -- x2 x1 x2 )";
        }

        public override void Call()
        {
            Forth.CoreWords.Swap.Call();
            Stack.Push(Stack.DataStack[Stack.DsP + 1]);
        }
    }
}
