using Godot;
using System;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FLN : Words
    {
        public FLN(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FLN";
            Description = "Return the natural logarithm of 'f'.<br/>"
                + "NOTE: If 'f' <= 0 pushes 0.0 onto the Floating Point stack.</br>"
                + "Example usage: 0.25 FLN";
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
                float res = (float)Math.Log((double)f);
                Stack.FPPush(res);
            }
        }
    }
}
