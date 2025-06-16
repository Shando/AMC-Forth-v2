using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Holds : Words
    {
        public Holds(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "HOLDS";
            Description = "Adds the string represented by 'c-addr' 'u' to the pictured numeric output string."
                + " NOTE: An ambiguous condition exists if HOLDS executes outside of a '<#' '#>' delimited number conversion."
                + " Example usage: S\" My String\" HOLDS";
            StackEffect = "( c-addr u -- )";
        }

        public override void Call()
        {
            Forth.CoreWords.Begin.Call();
            Forth.CoreWords.Dup.Call();
            Forth.CoreWords.While.Call();
            Stack.Push(1);
            Forth.CoreWords.Minus.Call();
            Forth.CoreWords.TwoDup.Call();
            Forth.CoreWords.Plus.Call();
            Forth.CoreWords.CStore.Call();
            Forth.CoreWords.Hold.Call();
            Forth.CoreWords.Repeat.Call();
            Forth.CoreWords.TwoDrop.Call();
        }
    }
}