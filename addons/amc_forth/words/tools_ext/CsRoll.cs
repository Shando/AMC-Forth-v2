using Godot;

namespace Forth.ToolsExt
{
    [GlobalClass]
    public partial class CsRoll : Words
    {
        public CsRoll(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CS-ROLL";
            Description = "Fetch the cell contents of the given address and display.";
            StackEffect = "( a-addr -- )";
            Immediate = true;
        }

        public override void Call()
        {
            Forth.CfStackRoll(Stack.Pop());
        }
    }
}
