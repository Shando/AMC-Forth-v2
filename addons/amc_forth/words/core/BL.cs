using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class BL : Words
    {
        public BL(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "BL";
            Description = "Return char, the ASCII character value of a space.";
            StackEffect = "( -- char )";
        }

        public override void Call()
        {
            Stack.Push(Terminal.BL.ToAsciiBuffer()[0]);
        }
    }
}
