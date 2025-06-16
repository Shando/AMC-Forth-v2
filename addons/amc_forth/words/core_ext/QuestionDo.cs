using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class QuestionDo : Words
    {
        public QuestionDo(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "?DO";
            Description =
                "Like DO, but check for the end condition before entering the loop body. "
                + "If satisfied, continue execution following nearest LOOP or LOOP+.";
            StackEffect = "( n1 n2 -- )";
            Immediate = true;
        }

        public override void Call()
        {
            Forth.Ram.SetInt(Forth.DictTopP, XtX);
            // mark NEXT cell as a destination for a backward branch
            Forth.CfPushDest(Forth.DictTopP + RAM.CellSize);
            // leave link address on the control stack
            Forth.LcfPush(Forth.DictTopP + RAM.CellSize);
            Forth.DictTopP += RAM.DCellSize; // move up to finish
            Forth.SaveDictTop(); // preserve dictionary state
        }

        public override void CallExec()
        {
            Forth.CoreWords.TwoDup.Call(); // make a copy of the parameters
            Forth.CoreWords.Equal.Call();

            if (Stack.Pop() == AMCForth.True)
            {
                Forth.CoreWords.TwoDrop.Call(); // already satisfied. remove the saved parameters
                // Skip ahead to the address in the next cell
                Forth.DictIp = Forth.Ram.GetInt(Forth.DictIp + RAM.CellSize);
            }
            else
            {
                Forth.CoreExtWords.TwoToR.Call(); // move limit and count to return stack
                Forth.DictIp += RAM.CellSize; // SKip over the forward reference
            }
        }
    }
}
