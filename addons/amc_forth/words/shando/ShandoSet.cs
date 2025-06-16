using Godot;

// Forth SHANDO word set

namespace Forth.Shando
{
    [GlobalClass]
    public partial class ShandoSet : RefCounted
    {
        public Abort Abort;
        public AbortQuote AbortQuote;
        public AddDollar AddDollar;
        public Blank Blank;
        public Bounds Bounds;
        public CPlusStore CPlusStore;
        public CToNumber CToNumber;
        public DashHead DashHead;
        public DashRot DashRot;
        public DashTail DashTail;
        public DashTrailing DashTrailing;
        public DULess DULess;
        public DumpP DumpP;
        public DumpR DumpR;
        public DumpRam DumpRam;
        public Erase Erase;
        public FetchPlus FetchPlus;
        public FourDrop FourDrop;
        public GetDollar GetDollar;
        public GetCurDollar GetCurDollar;
        public GetMaxDollar GetMaxDollar;
        public GreaterThanOrEqual GreaterThanOrEqual;
        public Holds Holds;
        public IncDollar IncDollar;
        public KeyA KeyA;
        public KeyQ KeyQ;
        public LessThanOrEqual LessThanOrEqual;
        public ReplaceDollar ReplaceDollar;
        public Rnd Rnd;
        public Scan Scan;
        public Search Search;
        public SetDollar SetDollar;
        public Skip Skip;
        public SlashString SlashString;
        public ThreeDrop ThreeDrop;
        public ThreeDup ThreeDup;
        public TwoNip TwoNip;
        public TwoTuck TwoTuck;
        public VarAddDollar VarAddDollar;
        public VarDollar VarDollar;
        public VarReplaceDollar VarReplaceDollar;
        public Within Within;

        private const string Wordset = "SHANDO";

        public ShandoSet(AMCForth _forth)
        {
            Abort = new(_forth, Wordset);
            AbortQuote = new(_forth, Wordset);
            AddDollar = new(_forth, Wordset);
            Blank = new(_forth, Wordset);
            Bounds = new(_forth, Wordset);
            CPlusStore = new(_forth, Wordset);
            CToNumber = new(_forth, Wordset);
            DashHead = new(_forth, Wordset);
            DashRot = new(_forth, Wordset);
            DashTail = new(_forth, Wordset);
            DashTrailing = new(_forth, Wordset);
            DULess = new(_forth, Wordset);
            DumpP = new(_forth, Wordset);
            DumpR = new(_forth, Wordset);
            DumpRam = new(_forth, Wordset);
            Erase = new(_forth, Wordset);
            FetchPlus = new(_forth, Wordset);
            FourDrop = new(_forth, Wordset);
            GetDollar = new(_forth, Wordset);
            GetCurDollar = new(_forth, Wordset);
            GetMaxDollar = new(_forth, Wordset);
            GreaterThanOrEqual = new(_forth, Wordset);
            Holds = new(_forth, Wordset);
            IncDollar = new(_forth, Wordset);
            KeyA = new(_forth, Wordset);
            KeyQ = new(_forth, Wordset);
            LessThanOrEqual = new(_forth, Wordset);
            ReplaceDollar = new(_forth, Wordset);
            Rnd = new(_forth, Wordset);
            Scan = new(_forth, Wordset);
            Search = new(_forth, Wordset);
            SetDollar = new(_forth, Wordset);
            Skip = new(_forth, Wordset);
            SlashString = new(_forth, Wordset);
            ThreeDrop = new(_forth, Wordset);
            ThreeDup = new(_forth, Wordset);
            TwoNip = new(_forth, Wordset);
            TwoTuck = new(_forth, Wordset);
            VarAddDollar = new(_forth, Wordset);
            VarDollar = new(_forth, Wordset);
            VarReplaceDollar = new(_forth, Wordset);
            Within = new(_forth, Wordset);
        }
    }
}
