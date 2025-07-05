using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FRot : Words
    {
        public FRot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FROT";
            Description = "Rotates the top 3 values on the floating-point stack.</br>"
                + "Example usage: 0.25 2.56 3.33 FROT";
            StackEffect = "( f1 f2 f3 -- f2 f3 f1 )";
        }

        public override void Call()
        {
            var f3 = Stack.FPPop();
            var f2 = Stack.FPPop();
            var f1 = Stack.FPPop();

            Stack.FPPush(f2);
            Stack.FPPush(f3);
            Stack.FPPush(f1);
        }
    }
}
