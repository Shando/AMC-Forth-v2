using Godot;

namespace Forth.Double
{
    [GlobalClass]
    public partial class DPlus : Words
    {
        public DPlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "D+";
            Description = "Add d1 to d2, leaving the sum d3.";
            StackEffect = "( d1 d2 -- d3 )";
        }

        public override void Call()
        {
            Stack.PushDint(Stack.PopDint() + Stack.PopDint());
        }
    }
}
