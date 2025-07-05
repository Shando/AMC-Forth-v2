using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FNegate : Words
    {
        public FNegate(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FNEGATE";
            Description = "Return 'f' * -1.</br>"
                + "Example usage: 0.25 FNEGATE";
            StackEffect = "( f -- -f )";
        }

        public override void Call()
        {
            Stack.FPPush(Stack.FPPop() * -1.0f);
        }
    }
}
