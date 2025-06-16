using Godot;

namespace Forth.Tools
{
    [GlobalClass]
    public partial class WordsT : Words
    {
        public WordsT(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "WORDS";
            Description =
                "List all the definition names in the word list of the search order. "
                + "Returns dictionary names first, including duplicates, then built-in names.";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            int word_len;
            var col = Name.Length + 1; // allow for the word itself in the first line!
            Forth.Util.PrintTerm(" ");

            if (Forth.DictP != Forth.DictTopP)
            {
                var p = Forth.DictP;

                while (p != -1) // dictionary is not empty
                {
                    Stack.Push(p + RAM.CellSize);
                    Forth.CoreWords.Count.Call();
                    // search word in addr, n format
                    Forth.CoreWords.Dup.Call();
                    // retrieve the size
                    word_len = Stack.Pop();

                    if (col + word_len + 1 >= Terminal.COLUMNS - 2)
                    {
                        Forth.Util.PrintTerm(Terminal.CRLF);
                        col = 0;
                    }

                    col += word_len + 1;
                    Forth.CoreWords.TypeF.Call(); // emit the dictionary entry name
                    Forth.Util.PrintTerm(" ");
                    p = Forth.Ram.GetInt(p); // drill down to the next entry
                }
            }

            // now go through the built-in names
            foreach (string entry in Forth.AllBuiltinNames)
            {
                word_len = entry.Length;

                if (col + word_len + 1 >= Terminal.COLUMNS - 2)
                {
                    Forth.Util.PrintTerm(Terminal.CRLF);
                    col = 0;
                }

                col += word_len + 1;
                Forth.Util.PrintTerm(entry + " ");
            }
        }
    }
}
