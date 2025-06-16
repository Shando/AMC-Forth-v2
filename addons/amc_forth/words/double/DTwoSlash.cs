using Godot;

namespace Forth.Double
{
    [GlobalClass]
    public partial class DTwoSlash : Words
    {
        public DTwoSlash(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "D2/";
            Description = "Divide d1 by 2, leaving the result d2.";
            StackEffect = "( d1 -- d2 )";
        }

        public override void Call()
        {
            Stack.SetDint(0, Stack.GetDint(0) >> 1);
        }
    }
}
