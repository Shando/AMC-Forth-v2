using Godot;

namespace Forth.Sound
{
    [GlobalClass]
    public partial class SetMasterVolume : Words
    {
        public SetMasterVolume(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SETMASTERVOLUME";
            Description =
                "Sets the master volume to the value denoted by 'vol' (0 - 100).<br/>"
                + "Example usage: 33 SETMASTERVOLUME";
            StackEffect = "( vol -- )";
        }

        public override void Call()
        {
            float vol = (float)Stack.Pop();

            if (vol < 0.0f) 
            {
                vol = 0.0f;
            } else if (vol > 100.0f) 
            {
                vol = 100.0f;
            }

            float db = (float)Mathf.LinearToDb(vol / 100.0f);
            AudioServer.SetBusVolumeDb(0, db);
        }
    }
}
