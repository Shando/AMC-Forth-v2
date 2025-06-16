using Godot;

// Forth TOOLS word set

namespace Forth.Tools
{
    [GlobalClass]
    public partial class ToolsSet : RefCounted
    {
        public Question Question;
        public DotS DotS;
        public WordsT WordsT;
        private const string Wordset = "TOOLS";

        public ToolsSet(AMCForth _forth)
        {
            Question = new(_forth, Wordset);
            DotS = new(_forth, Wordset);
            WordsT = new(_forth, Wordset);
        }
    }
}
