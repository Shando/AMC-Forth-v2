using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FLOG : Words
    {
        public FLOG(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FLOG";
            Description = "Return the the base-ten logarithm of 'f'.<br/>"
                + "NOTE: If 'f' <= 0 pushes 0.0 onto the FLoating Point stack.</br>"
                + "Example usage: 6.5 FLOG";
            StackEffect = "( f -- f )";
        }

        public override void Call()
        {
            float f = Stack.FPPop();

            if (f <= 0.0f)
            {
                Stack.FPPush(0.0f);
            }
            else
            {
                float res = (float)Math.Log10((double)f);
                Stack.FPPush(res);
            }
        }
    }
}
