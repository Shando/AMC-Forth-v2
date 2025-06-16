using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Dot : Words
    {
        public Dot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = ".";
            Description = "Display the value, x, on the top of the stack.";
            StackEffect = "( x -- )";
        }

        public override void Call()
        {
            var fmt = Forth.Ram.GetInt(Map.Base) == 10 ? "F0" : "X";
            var num = Stack.Pop();
            Forth.Util.PrintTerm(num.ToString(fmt) + " ");
        }
    }
}
