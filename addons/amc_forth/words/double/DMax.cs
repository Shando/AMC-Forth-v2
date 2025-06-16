using Godot;

namespace Forth.Double
{
    [GlobalClass]
    public partial class DMax : Words
    {
        public DMax(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DMAX";
            Description = "Return d3, the greater of d1 and d2.";
            StackEffect = "( d1 d2 -- d3 )";
        }

        public override void Call()
        {
            var d2 = Stack.PopDint();

            if (d2 > Stack.GetDint(0))
            {
                Stack.SetDint(0, d2);
            }
        }
    }
}
