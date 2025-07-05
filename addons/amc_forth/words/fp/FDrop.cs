using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FDrop : Words
    {
        public FDrop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FDROP";
            Description = "Removes the top value from the Floating Point stack.</br>"
                + "Example usage: FDROP";
            StackEffect = "( -- n )";
        }

        public override void Call()
        {
            Stack.FPPop();
        }
    }
}
