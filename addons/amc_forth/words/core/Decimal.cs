using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Decimal : Words
    {
        public Decimal(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DECIMAL";
            Description = "Sets BASE to 10.";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Stack.Push(10);
            Forth.CoreWords.Base.Call();
            Forth.CoreWords.Store.Call();
        }
    }
}
