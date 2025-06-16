using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Skip : Words
    {
        public Skip(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SKIP";
            Description =
                " Search the string specified by 'c-addr1' 'u1' for the character specified by 'c'."
                + " Skip all characters equal to 'c'. The result is the string minus all occurrences of 'c', or is empty."
                + " NOTE: SKIP is limited to single-byte (ASCII) characters."
                + " Example usage: S\" My String\" CHAR A SKIP";
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
             *          WHILE ( len <> 0 )
             *              OVER C@ R@ =    \ test 1st char
             *          WHILE ( R@ = char )
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
            Forth.CoreWords.Equal.Call();
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
