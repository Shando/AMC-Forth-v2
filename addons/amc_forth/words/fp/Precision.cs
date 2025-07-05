using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class Precision : Words
    {
        public Precision(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "PRECISION";
            Description = "Return the number of significant digits currently used by F., F.$, FE., FE.$, FS. or FS.$ to n.</br>"
                + "NOTE: The number of digits will be pushed to the Data stack.</br>"
                + "Example usage: PRECISION";
            StackEffect = "(DS: -- n )";
        }

        public override void Call()
        {
            Stack.Push(Forth.precision);
        }
    }
}
