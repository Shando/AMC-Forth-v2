using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class Again : Words
    {
        public Again(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "AGAIN";
            Description =
                "Unconditionally branch back to the point immediately following "
                + "the nearest previous BEGIN.";
            StackEffect = "( dest -- )";
            Immediate = true;
        }

        public override void Call()
        {
            // copy the execution token
            Forth.Ram.SetInt(Forth.DictTopP, XtX);
            // The link back
            Forth.Ram.SetInt(Forth.DictTopP + RAM.CellSize, Forth.CfPopDest());
            Forth.DictTopP += RAM.DCellSize; // two cells up and done
            Forth.SaveDictTop(); // preserve the state
        }

        public override void CallExec()
        {
            // Unconditionally branch
            Forth.DictIp = Forth.Ram.GetInt(Forth.DictIp + RAM.CellSize);
        }
    }
}
