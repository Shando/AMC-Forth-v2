using Godot;

namespace Forth.Sound
{
    [GlobalClass]
    public partial class PauseMusic : Words
    {
        public PauseMusic(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "PAUSEMUSIC";
            Description = 
                "Pauses any music that is currently playing."
                + " Example usage: PAUSEMUSIC";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Forth.music.CallDeferred("set_stream_paused", true);
        }
    }
}
