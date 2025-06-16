using Godot;

namespace Forth.Double
{
    [GlobalClass]
    public partial class DMinus : Words
    {
        public DMinus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "D-";
            Description = "Subtract d2 from d1, leaving the difference d3.";
            StackEffect = "( d1 d2 -- d3 )";
        }

        public override void Call()
        {
            var t = Stack.PopDint();
            Stack.PushDint(Stack.PopDint() - t);
        }
    }
}
