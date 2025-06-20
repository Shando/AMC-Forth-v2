using Godot;

namespace Forth.Sound
{
    [GlobalClass]
    public partial class ResumeMusic : Words
    {
        public ResumeMusic(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "RESUMEMUSIC";
            Description =
                "Resumes music if it is currently paused.<br/>"
                + "Example usage: RESUMEMUSIC";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Forth.music.CallDeferred("set_stream_paused", false);
        }
    }
}
