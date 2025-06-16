using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Scan : Words
    {
        public Scan(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SCAN";
            Description =
                " Search the string specified by 'c-addr1' 'u1' for the character specified by 'c'."
                + " Skip all characters not equal to 'c'. The result starts with 'c' or is empty."
                + " NOTE: SCAN is limited to single-byte (ASCII) characters."
                + " NOTE2: Use SEARCH to search for multi-byte characters."
                + " Example usage: S\" My String\" CHAR t SCAN";
            StackEffect = "( c-addr1 u1 c -- c-addr2 u2 )";
        }

        public override void Call()
        {
            /*
             * From https://www.reddit.com/r/Forth/comments/1cbzue9/just_learning_forth_suggestions_to_make_this_more/
             * 
             *          >R                   \ remember char
             *          BEGIN
             *              DUP
             *          WHILE ( len<>0 )
             *              OVER C@ R@ <>    \ test 1st char
             *          WHILE ( R@<>char )
             *              1 /STRING        \ cut off 1st char
             *          REPEAT
             *          THEN
             *          R> DROP              \ Rdrop char
             */
            Stack.RPush(Stack.Pop());
            Forth.CfPushDest(Forth.DictTopP - RAM.CellSize);
            Stack.Push(Stack.DataStack[Stack.DsP]);
            Forth.CoreWords.If.Call();
            Stack.Push(Stack.DataStack[Stack.DsP + 1]);
            Stack.Push(Forth.Ram.GetByte(Stack.Pop()));
            var t = Stack.RPop();
            Stack.Push(t);
            Stack.RPush(t);
            Forth.CoreExtWords.NotEqual.Call();
            Forth.CoreWords.If.Call();
            Stack.Push(1);
            Forth.ShandoWords.SlashString.Call();
            Forth.CoreWords.Repeat.Call();
            Forth.CoreWords.Then.Call();
            Stack.Push(Stack.RPop());
            Stack.Pop();
        }
    }
}
