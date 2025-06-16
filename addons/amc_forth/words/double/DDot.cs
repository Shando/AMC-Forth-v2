using Godot;

namespace Forth.Double
{
    [GlobalClass]
    public partial class DDot : Words
    {
        public DDot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "D.";
            Description = "Display the top cell pair on the stack as a signed double integer.";
            StackEffect = "( d -- )";
        }

        public override void Call()
        {
            var fmt = Forth.Ram.GetInt(Map.Base) == 10 ? "F0" : "X";
            var num = Stack.PopDint();
            Forth.Util.PrintTerm(num.ToString(fmt) + " ");
        }
    }
}
