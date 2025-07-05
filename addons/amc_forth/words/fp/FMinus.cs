using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FMinus : Words
    {
        public FMinus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F-";
            Description = "Subtract 'f2' from 'f1' returning 'f3'.</br>"
                + "Example usage: 0.25 0.15 F-";
            StackEffect = "( f1 f2 -- f3 )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();

            Stack.FPPush(f1 - f2);
        }
    }
}
