using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FTRUNC : Words
    {
        public FTRUNC(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FTRUNC";
            Description = "Return 'f' rounded to the nearest integral value using 'round towards zero' rule.<br>"
                + "Example usage: 15.56 FTRUNC";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();
            int i = (int)f;
            f = (float)i;
            Stack.FPPush(f);
        }
    }
}
