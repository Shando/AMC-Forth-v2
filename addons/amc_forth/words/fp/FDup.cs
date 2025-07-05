using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FDup : Words
    {
        public FDup(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FDUP";
            Description = "Duplicates the top value on the Floating Point stack.</br>"
                + "Example usage: 0.25 FDUP";
            StackEffect = "( f -- f f )";
        }

        public override void Call()
        {
            var f = Stack.FPPop();
            Stack.FPPush(f);
            Stack.FPPush(f);
        }
    }
}
