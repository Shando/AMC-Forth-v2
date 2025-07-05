using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class SetDashPrecision : Words
    {
        public SetDashPrecision(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SET-PRECISION";
            Description = "Set the number of significant digits currently used by F., F.$, FE., FE.$, FS. or FS.$ to n.</br>"
                + "NOTE: The number of digits must be on the Data stack.</br>"
                + "Example usage: 6 SET-PRECISION";
            StackEffect = "(DS: n -- )";
        }

        public override void Call()
        {
            Forth.precision = Stack.Pop();
        }
    }
}
