using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class If : Words
    {
        public If(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "IF";
            Description = "Place forward reference origin on the control flow stack.";
            StackEffect = "( -- orig )";
            Immediate = true;
        }

        public override void Call()
        {
            Forth.Ram.SetInt(Forth.DictTopP, XtX);
            // leave link address on the control stack
            Forth.CfPushOrig(Forth.DictTopP + RAM.CellSize);
            Forth.DictTopP += RAM.DCellSize; // move up to finish
            Forth.SaveDictTop(); // preserve dictionary state
        }

        public override void CallExec()
        {
            // Branch to ELSE if top of stack not TRUE
            // ( x -- )
            if (Stack.Pop() == 0)
            {
                Forth.DictIp = Forth.Ram.GetInt(Forth.DictIp + RAM.CellSize);
            }
            else
            {
                // TRUE, so skip over the link and continue executing
                Forth.DictIp += RAM.CellSize;
            }
        }
    }
}
