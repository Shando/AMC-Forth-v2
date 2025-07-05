using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FZeroEquals : Words
    {
        public FZeroEquals(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F0=";
            Description = "Return TRUE if 'f' is equal to 0.0 else return FALSE.<br/>"
                + "Example usage: 0.0 0=";
            StackEffect = "(FP: f -- ) (DS: -- flag )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();

            if (f == 0.0f)
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
