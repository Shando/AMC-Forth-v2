using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Search : Words
    {
        public Search(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SEARCH";
            Description =
                "Search the string specified by 'c-addr1' 'u1' for the string specified by 'c-addr2' 'u2'."
                + " If 'flag' is 'TRUE', a match was found at 'c-addr3' with 'u3' characters remaining."
                + " If 'flag' is 'FALSE' there was no match, and 'c-addr3' is 'c-addr1' and 'u3' is 'u1'."
                + " NOTE: the two strings can both be string variables, or can be one string variable and one string created using S\"."
                + "     However, they cannot be two strings created using S\"."
                + " Example usage: myVar1 GET$ S\" h\" SEARCH";
            StackEffect = "( c-addr1 u1 c-addr2 u2 -- c-addr3 u3 flag )";
        }

        public override void Call()
        {
            /*
             *  2>r begin 2dup r@ min 2r@ compare while dup while
             *  1 /string repeat 0 else -1 then 2r> 2drop
             */
            Stack.RPushDint(Stack.PopDint());
            Forth.CoreWords.Begin.Call();
            Forth.CoreWords.TwoDup.Call();
            Forth.CoreWords.RFetch.Call();
            Forth.CoreWords.Min.Call();
            Forth.CoreExtWords.TwoRFetch.Call();
            Forth.StringWords.Compare.Call();
            Forth.CoreWords.While.Call();
            Stack.Push(Stack.DataStack[Stack.DsP]);
            Forth.CoreWords.While.Call();
            Stack.Push(1);
            Forth.ShandoWords.SlashString.Call();
            Forth.CoreWords.Repeat.Call();
            Stack.Push(0);
            Forth.CoreWords.Else.Call();
            Stack.Push(-1);
            Forth.CoreWords.Then.Call();
            Stack.PushDint(Stack.RPopDint());
            Stack.Pop();
            Stack.Pop();
        }
    }
}
