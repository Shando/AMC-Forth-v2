using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FLess : Words
    {
        public FLess(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F<";
            Description = "Return TRUE if 'f1' is less than 'f2' else returns FALSE.</br>"
                + "Example usage: 0.25 0.33 F<";
            StackEffect = "(FP: f1 f2 -- ) (DS: -- flag )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();

            if (f1 < f2)
            {
                Stack.Push(AMCForth.True);
            }
            else
            {
                Stack.Push(AMCForth.False);
            }
        }
    }
}
