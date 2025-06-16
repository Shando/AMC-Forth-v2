using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class OnePlus : Words
    {
        public OnePlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "1+";
            Description = "Add one to n1, leaving n2.";
            StackEffect = "( n1 -- n2 )";
        }

        public override void Call()
        {
            Stack.Push(1);
            Forth.CoreWords.Plus.Call();
        }
    }
}
