using Godot;

namespace Forth.Sound
{
    [GlobalClass]
    public partial class StopMusic : Words
    {
        public StopMusic(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "STOPMUSIC";
            Description = 
                "Stops any music that is currently playing."
                + " Example usage: STOPMUSIC";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Forth.music.CallDeferred("stop");
        }
    }
}
