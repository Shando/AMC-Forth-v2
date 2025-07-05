using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FMAX : Words
    {
        public FMAX(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FMAX";
            Description = "Return the greater of 'f1' and 'f2'.</br>"
                + "Example usage: 0.25 5.55 FMAX";
            StackEffect = "( f1 f2 -- f )";
        }

        public override void Call()
        {
            float f2 = Stack.FPPop();
            float f1 = Stack.FPPop();

            if (f1 >= f2)
            {
                Stack.FPPush(f1);
            }
            else
            {
                Stack.FPPush(f2);
            }
        }
    }
}
