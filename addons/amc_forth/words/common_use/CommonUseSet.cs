using Godot;

// Forth COMMON USE word set

namespace Forth.CommonUse
{
    [GlobalClass]
    public partial class CommonUseSet : RefCounted
    {
        public CommaQuote CommaQuote;
        public TwoPlus TwoPlus;
        public TwoMinus TwoMinus;
        public MMinus MMinus;
        public MSlash MSlash;
        public Not Not;
        public NumberQuestion NumberQuestion;

        private const string Wordset = "COMMON USE";

        public CommonUseSet(AMCForth _forth)
        {
            CommaQuote = new(_forth, Wordset);
            TwoPlus = new(_forth, Wordset);
            TwoMinus = new(_forth, Wordset);
            MMinus = new(_forth, Wordset);
            MSlash = new(_forth, Wordset);
            Not = new(_forth, Wordset);
            NumberQuestion = new(_forth, Wordset);
        }
    }
}
