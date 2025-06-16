using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Unloop : Words
    {
        public Unloop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "UNLOOP";
            Description = "Discard the loop parameters for the current nesting level.";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Stack.RPopDint();
        }
    }
}
