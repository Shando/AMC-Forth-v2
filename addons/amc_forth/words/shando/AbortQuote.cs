using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class AbortQuote : Words
    {
        public AbortQuote(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "ABORT\"";
            Description = "Parse 'ccc' delimited by a \" (double quote). Remove 'x1' from the stack."
                + " If any bit of 'x1' is not zero, display 'ccc' and perform an implementation-defined abort sequence that includes the function of ABORT."
                + " Example usage: ABORT\" Error: Division by zero!\"";
            StackEffect = "Compile: ( \"ccc<quote>\" -- ) | Run: (i * x x1-- | i * x ) (R: j * x-- | j * x )";
            Immediate = true;
        }

        public override void Call()
        {
            Stack.Push("\"".ToAsciiBuffer()[0]);
            Forth.CoreExtWords.Parse.Call();
            var l = Stack.Pop();
            var src = Stack.Pop();

            if (Forth.State) // different compilation behavior
            {
                Forth.Ram.SetInt(Forth.DictTopP, XtX);
                Forth.DictTopP += RAM.CellSize; // store the value
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
            else
            {
                for (int i = 0; i < l; i++) // just copy it at the end of the dictionary as a temporary area
                {
                    Forth.Ram.SetByte(Forth.DictTopP + i, Forth.Ram.GetByte(src + i));
                }

                // push the return values back on
                Stack.Push(Forth.DictTopP);
                Stack.Push(l);

                Forth.CoreWords.TypeF.Call();
                Forth.CoreWords.CR.Call();
                Forth.ShandoWords.Abort.Call();
            }
        }

        public override void CallExec()
        {
            var l = Forth.Ram.GetByte(Forth.DictIp + RAM.CellSize);
            Stack.Push(Forth.DictIp + RAM.CellSize + 1); // address of the string start
            Stack.Push(l); // length of the string
            // send to the terminal
            Forth.CoreWords.TypeF.Call();
            Forth.CoreWords.CR.Call();
            Forth.ShandoWords.Abort.Call();
        }
    }
}
