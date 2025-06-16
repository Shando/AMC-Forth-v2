using Godot;

// Forth AMC Extensions word set

namespace Forth.AMCExt
{
    [GlobalClass]
    public partial class AMCExtSet : RefCounted
    {
        //public BlinkV BlinkV;
        //public BoldV BoldV;
        //public CursorHide CursorHide;
        //public CursorShow CursorShow;
        public Help Help;
        public HelpS HelpS;
        public HelpWS HelpWS;
        public In In;
        public InAddr InAddr;
        //public InvisibleV InvisibleV;
        public Listen Listen;
        public ListenX ListenX;
        public LoadSnap LoadSnap;
        //public LowV LowV;
        //public NomodeV NomodeV;
        public Out Out;
        public OutAddr OutAddr;
        public PTimer PTimer;
        public PTimerX PTimerX;
        public PStop PStop;
        //public PopXY PopXY;
        //public PushXY PushXY;
        //public ReverseV ReverseV;
        public SaveSnap SaveSnap;
        //public UnderlineV UnderlineV;
        public Unlisten Unlisten;
  
        private const string Wordset = "AMC EXT";

        public AMCExtSet(AMCForth _forth)
        {
            //BlinkV = new(_forth, Wordset);
            //BoldV = new(_forth, Wordset);
            //CursorHide = new(_forth, Wordset);
            //CursorShow = new(_forth, Wordset);
            Help = new(_forth, Wordset);
            HelpS = new(_forth, Wordset);
            HelpWS = new(_forth, Wordset);
            In = new(_forth, Wordset);
            InAddr = new(_forth, Wordset);
            //InvisibleV = new(_forth, Wordset);
            Listen = new(_forth, Wordset);
            ListenX = new(_forth, Wordset);
            LoadSnap = new(_forth, Wordset);
            //LowV = new(_forth, Wordset);
            //NomodeV = new(_forth, Wordset);
            Out = new(_forth, Wordset);
            OutAddr = new(_forth, Wordset);
            PTimer = new(_forth, Wordset);
            PTimerX = new(_forth, Wordset);
            PStop = new(_forth, Wordset);
            //PopXY = new(_forth, Wordset);
            //PushXY = new(_forth, Wordset);
            //ReverseV = new(_forth, Wordset);
            SaveSnap = new(_forth, Wordset);
            //UnderlineV = new(_forth, Wordset);
            Unlisten = new(_forth, Wordset);
        }
    }
}
