using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FSwap : Words
    {
        public FSwap(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FSWAP";
            Description = "Swaps the top two values on the Floating Point stack.</br>"
                + "Example usage: 0.25 2.25 FSWAP";
            StackEffect = "( f1 f2 -- f2 f1 )";
        }

        public override void Call()
        {
            var f2 = Stack.FPPop();
            var f1 = Stack.FPPop();
            Stack.FPPush(f2);
            Stack.FPPush(f1);
        }
    }
}
