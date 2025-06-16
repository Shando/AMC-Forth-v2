using Godot;

namespace Forth.CommonUse
{
    [GlobalClass]
    public partial class TwoMinus : Words
    {
        public TwoMinus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "2-";
            Description = "Subtract two from n1, leaving n2.";
            StackEffect = "( n1 -- n2 )";
            PreVal = 1;
            PostVal = 1;
        }

        public override void Call()
        {
            Stack.Push(2);
            Forth.CoreWords.Minus.Call();
        }
    }
}
