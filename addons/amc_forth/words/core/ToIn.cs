using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class ToIn : Words
    {
        public ToIn(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = ">IN";
            Description =
                "Return address of a cell containing the offset, in characters, "
                + "from the start of the input buffer to the start of the current "
                + "parse position.";
            StackEffect = "( -- a-addr )";
        }

        public override void Call()
        {
            // terminal pointer or...
            if (Forth.SourceId == -1)
            {
                Stack.Push(Map.BuffToIn);
            }
            // file buffer pointer
            else if (Forth.SourceId != 0)
            {
                Stack.Push(Forth.SourceId + Map.FileBuffPtrOffset);
            }
        }
    }
}
