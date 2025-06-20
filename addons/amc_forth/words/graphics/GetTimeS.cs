using Godot;
using System;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class GetTimeS : Words
    {
        public GetTimeS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETTIMES";
            Description =
                "Get the current System Time in seconds (no decimal) as a double.<br/>"
                + "Example usage: GETTIMES 10 D.R";
            StackEffect = "( -- d )";
        }

        public override void Call()
        {
            long t = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) / 1000;
            Stack.PushDint(t);
        }
    }
}
