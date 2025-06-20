using Godot;
using System.Timers;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Abort : Words
    {
        public Abort(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "ABORT";
            Description = "Empty the data stack and perform the function of QUIT, which includes emptying the return stack, without displaying a message.<br/>"
                + "Example usage: ABORT";
            StackEffect = "( i * x -- ) ( R: j * x -- )";
        }

        public override void Call()
        {
            var timer = new System.Timers.Timer(3000); // Create a timer with a 3-second interval
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Forth.bQuit = true;
            Forth.main.CallDeferred("reset");
        }
    }
}