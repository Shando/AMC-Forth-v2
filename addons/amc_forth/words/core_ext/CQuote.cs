using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class CQuote : Words
    {
        public CQuote(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "C\"";
            Description =
                "Return the counted-string address of the string, terminated by \" "
                + "which is in a temporary buffer. For compilation only";
            StackEffect = "( 'string' -- c-addr )";
            Immediate = true;
        }

        public override void Call()
        {
            Stack.Push("\"".ToAsciiBuffer()[0]);
            Forth.CoreExtWords.Parse.Call();

            if (Forth.State) // compilation behavior
            {
                // copy the execution token
                Forth.Ram.SetInt(Forth.DictTopP, XtX); // store the value
                var l = Stack.Pop(); // length of the string
                var src = Stack.Pop(); // first byte address
                Forth.DictTopP += RAM.CellSize;
                Forth.Ram.SetByte(Forth.DictTopP, l); // store the length
                Forth.DictTopP += 1; // beginning of string characters

                // compile the string into the dictionary
                for (int i = 0; i < l; i++)
                {
                    Forth.Ram.SetByte(Forth.DictTopP, Forth.Ram.GetByte(src + i));
                    Forth.DictTopP += 1;
                }

                Forth.CoreWords.Align.Call(); // this will align the dict top and save it
            }
        }

        public override void CallExec()
        {
            var l = Forth.Ram.GetByte(Forth.DictIp + RAM.CellSize);
            Stack.Push(Forth.DictIp + RAM.CellSize); // address of the string start
            // moves to string cell for l in 0..3, then one cell past for l in 4..7, etc.
            Forth.DictIp += ((l / RAM.CellSize) + 1) * RAM.CellSize;
        }
    }
}
