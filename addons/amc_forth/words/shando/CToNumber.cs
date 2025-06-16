using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class CToNumber : Words
    {
        public CToNumber(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "C>NUMBER";
            Description =
                "Convert the number represented by the character 'c' to its numeric equivalent 'u'."
                + " Example usage: CHAR 5 C>NUMBER";
            StackEffect = "( c -- u )";
        }

        public override void Call()
        {
            Forth.CoreWords.BracketCare.Call();
            Stack.Push(0);
            Forth.CoreWords.Minus.Call();
            Forth.CoreWords.Dup.Call();
            Stack.Push(9);
            Forth.CoreWords.GreaterThan.Call();
            Forth.CoreWords.If.Call();
            Forth.CoreWords.LeftBracket.Call();
            Forth.CoreWords.Care.Call();
            Stack.Push(65);
            Forth.CoreWords.Care.Call();
            Stack.Push(0);
            Forth.CoreWords.Minus.Call();
            Stack.Push(-10);
            Forth.CoreWords.Minus.Call();
            Forth.CoreWords.RightBracket.Call();
            Forth.CoreWords.Literal.Call();
            Forth.CoreWords.Minus.Call();
            Forth.CoreWords.Else.Call();
            Forth.CoreWords.Exit.Call();
            Forth.CoreWords.Then.Call();
            Forth.CoreWords.Dup.Call();
            Stack.Push(10);
            Forth.CoreWords.LessThan.Call();
            Forth.CoreWords.If.Call();
            Forth.CoreWords.Drop.Call();
            Stack.Push(36);
            Forth.CoreWords.Exit.Call();
            Forth.CoreWords.Then.Call();
            Forth.CoreWords.Dup.Call();
            Stack.Push(35);
            Forth.CoreWords.GreaterThan.Call();
            Forth.CoreWords.If.Call();
            Forth.CoreWords.LeftBracket.Call();
            Forth.CoreWords.Care.Call();
            Stack.Push(97);
            Forth.CoreWords.Care.Call();
            Stack.Push(65);
            Forth.CoreWords.Minus.Call();
            Forth.CoreWords.RightBracket.Call();
            Forth.CoreWords.Literal.Call();
            Forth.CoreWords.Minus.Call();
            Forth.CoreWords.Then.Call();
            Forth.CoreWords.Dup.Call();
            Stack.Push(10);
            Forth.CoreWords.LessThan.Call();
            Forth.CoreWords.If.Call();
            Forth.CoreWords.Drop.Call();
            Stack.Push(36);
            Forth.CoreWords.Exit.Call();
            Forth.CoreWords.Then.Call();
        }
    }
}
