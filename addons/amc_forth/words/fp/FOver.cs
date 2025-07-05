using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FOver : Words
    {
        public FOver(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FOVER";
            Description = "Place a copy of the 2nd item on the Floating Point stack on top of the Floating Point stack.</br>"
                + "Example usage: 0.25 6.75 FOVER";
            StackEffect = "( f1 f2 -- f1 f2 f1 )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();

            Stack.FPPush(f1);
            Stack.FPPush(f2);
            Stack.FPPush(f1);
        }
    }
}
