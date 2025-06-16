using Godot;

namespace Forth.Tools
{
    [GlobalClass]
    public partial class DotS : Words
    {
        public DotS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = ".S";
            Description = "Display the contents of the data stack using the current base.";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            var pointer = Stack.DataStackTop;
            var fmt = Forth.Ram.GetInt(Map.Base) == 10 ? "F0" : "X";
            Forth.Util.RprintTerm("");

            while (pointer >= Stack.DsP)
            {
                Forth.Util.PrintTerm(" " + Stack.DataStack[pointer].ToString(fmt));
                pointer -= 1;
            }

            Forth.Util.PrintTerm(" <-Top ");
        }
    }
}
