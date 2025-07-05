using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FDepth : Words
    {
        public FDepth(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FDEPTH";
            Description = "Return the number of values contained on the Floating Point stack onto the Data stack.</br>"
                + "Example usage: FDEPTH";
            StackEffect = "( -- n )";
        }

        public override void Call()
        {
            Stack.Push(1000 - Stack.FPsP);
        }
    }
}
