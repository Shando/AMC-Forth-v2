using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Do : Words
    {
        public Do(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DO";
            Description =
                "Establish loop parameters, initial index n2 on the top of stack, "
                + "with the limit value n1 below it. These are transferred to the "
                + "return stack when DO is executed.";
            StackEffect = "( n1 n2 -- )";
            Immediate = true;
        }

        public override void Call()
        {
            Forth.Ram.SetInt(Forth.DictTopP, XtX);
            // mark THIS cell as a destination for a backward branch
            Forth.CfPushDest(Forth.DictTopP);
            Forth.DictTopP += RAM.CellSize; // move up to finish
            Forth.SaveDictTop(); // preserve dictionary state
        }

        public override void CallExec()
        {
            // push limit, then count on return stack
            Forth.CoreExtWords.TwoToR.Call();
        }
    }
}
