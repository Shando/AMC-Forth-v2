using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Source : Words
    {
        public Source(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SOURCE";
            Description = "Return the address and length of the input buffer.";
            StackEffect = "( -- c-addr u )";
        }

        public override void Call()
        {
            if (Forth.SourceId == -1)
            {
                Stack.Push(Map.BuffSourceStart);
                Stack.Push(Map.BuffSourceSize);
            }
            else if (Forth.SourceId != 0)
            {
                Stack.Push(Forth.SourceId + Map.FileBuffDataOffset);
                Stack.Push(Map.FileBuffDataSize);
            }
        }
    }
}
