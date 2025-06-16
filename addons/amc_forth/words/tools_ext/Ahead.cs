using Godot;

namespace Forth.ToolsExt
{
    [GlobalClass]
    public partial class Ahead : Words
    {
        public Ahead(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "AHEAD";
            Description = "Place forward reference origin on the control flow stack.";
            StackEffect = "( -- orig )";
            Immediate = true;
        }

        public override void Call()
        {
            Forth.Ram.SetInt(Forth.DictTopP, XtX); // copy the execution token
            Forth.CfPushOrig(Forth.DictTopP + RAM.CellSize); // leave link address on the control stack
            Forth.DictTopP += RAM.DCellSize; // move two cells up to finish
            Forth.SaveDictTop(); // preserve dictionary state
        }

        public override void CallExec()
        {
            // Branch to ELSE if top of stack not TRUE.
            // ( x -- )
            // Skip ahead to the address in the next cell
            Forth.DictIp = Forth.Ram.GetInt(Forth.DictIp + RAM.CellSize);
        }
    }
}
