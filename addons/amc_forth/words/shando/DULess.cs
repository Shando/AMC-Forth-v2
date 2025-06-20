using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class DULess : Words
    {
        public DULess(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DU<";
            Description =
                "Return 'TRUE' if and only if the double precision value 'd1' is less than double precision value 'd2'.<br/>"
                + "Example usage: 19000000000000000000 20000000000000000000 DU<";
            StackEffect = "( d1 d2 -- flag )";
        }

        public override void Call()
        {
            var d2 = Stack.PopDint();

            if (Stack.PopDint() < d2)
                Stack.Push(AMCForth.True);
            else
                Stack.Push(AMCForth.False);
        }
    }
}
