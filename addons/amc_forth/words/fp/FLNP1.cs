using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FLNP1 : Words
    {
        public FLNP1(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FLNP1";
            Description = "Return the natural logarithm of 'f' plus one.<br/>"
                + "NOTE: If 'f' <= -1 pushes 0.0 onto the Floating Point stack.</br>"
                + "Example usage: 0.25 FLNP1";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            float f = Stack.FPPop() + 1.0f;
            Stack.FPPush(f);
            Forth.FloatingPointWords.FLN.Call();
        }
    }
}
