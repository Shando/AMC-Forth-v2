using Godot;

namespace Forth.File
{
    [GlobalClass]
    public partial class RO : Words
    {
        public RO(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "R/O";
            Description = "Return the read-only file access method.";
            StackEffect = "( -- fam )";
        }

        public override void Call()
        {
            Stack.Push((int)FileAccess.ModeFlags.Read);
        }
    }
}
