using Godot;
using System;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class GetTimeMS : Words
    {
        public GetTimeMS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETTIMEMS";
            Description =
                "Get the current System Time in milliseconds (no decimal) as a double.<br/>"
                + "Example usage: GETTIMEMS 10 D.R";
            StackEffect = "( -- d )";
        }

        public override void Call()
        {
            long t = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Stack.PushDint(t);
        }
    }
}
