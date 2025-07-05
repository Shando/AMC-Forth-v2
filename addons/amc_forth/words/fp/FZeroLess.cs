using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FZeroLess : Words
    {
        public FZeroLess(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F0<";
            Description = "Return TRUE if 'f' is less than 0 else return FALSE.<br/>"
                +   "Example usage: -0.15 0<";
            StackEffect = "(FP: f -- ) (DS: -- flag )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();

            if (f < 0.0f)
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
