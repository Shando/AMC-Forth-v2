using Godot;

namespace Forth.CoreExt
{
    [GlobalClass]
    public partial class UGreaterThan : Words
    {
        public UGreaterThan(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "U>";
            Description = "Return true if and only if u1 is greater than u2.";
            StackEffect = "( u1 u2 -- flag )";
        }

        public override void Call()
        {
            var u2 = (uint)Stack.Pop();

            if ((uint)Stack.Pop() > u2)
            {
                Stack.Push(AMCForth.True);
            }
            else
            {
                Stack.Push(AMCForth.False);
            }
        }
    }
}
