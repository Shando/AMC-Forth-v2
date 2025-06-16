using Godot;

namespace Forth.Sound
{
    [GlobalClass]
    public partial class PlaySound : Words
    {
        public PlaySound(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "PLAYSOUND";
            Description =
                "Plays the sound effect file denoted by 'id' at the volume denoted by 'vol' (0 - 100)."
                + " For example: id = 7 will play user://Sounds/Sfx/007.mp3"
                + " Example usage: 7 33 PLAYSOUND";
            StackEffect = "( id vol -- )";
        }

        public override void Call()
        {
            float vol = (float)Stack.Pop();
            int id = (int)Stack.Pop();

            if (vol < 0.0f)
            {
                vol = 0.0f;
            }
            else if (vol > 100.0f)
            {
                vol = 100.0f;
            }

            string Format = "000";
            string path = "user://Sounds/Sfx/" + id.ToString(Format) + ".mp3";

            FileAccess file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
            AudioStreamMP3 sound = new AudioStreamMP3();
            sound.Data = file.GetBuffer((int)file.GetLength());

            Forth.sfx.CallDeferred("set_stream", sound);
            Forth.sfx.VolumeDb = (float)Mathf.LinearToDb(vol / 100.0f);
            Forth.sfx.CallDeferred("play");
        }
    }
}
