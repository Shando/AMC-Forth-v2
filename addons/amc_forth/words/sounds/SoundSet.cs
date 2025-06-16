using Godot;

// Forth SOUND word set

namespace Forth.Sound
{
    [GlobalClass]
    public partial class SoundSet : RefCounted
    {
        public PlayMusic PlayMusic;
        public PlaySound PlaySound;
        public PauseMusic PauseMusic;
        public ResumeMusic ResumeMusic;
        public StopMusic StopMusic;
        public SetMasterVolume SetMasterVolume;

        private const string Wordset = "SOUND";

        public AMCForth forth;

        public SoundSet(AMCForth _forth)
        {
            PlayMusic = new(_forth, Wordset);
            PlaySound = new(_forth, Wordset);
            PauseMusic = new(_forth, Wordset);
            ResumeMusic = new(_forth, Wordset);
            StopMusic = new(_forth, Wordset);
            SetMasterVolume = new(_forth, Wordset);

            forth = _forth;
        }
    }
}
