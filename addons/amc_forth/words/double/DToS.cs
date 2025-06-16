using Godot;

namespace Forth.Double
{
    [GlobalClass]
    public partial class DToS : Words
    {
        public DToS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "D>S";
            Description = "Convert double to single, discarding the most significant cell.";
            StackEffect = "( d -- n )";
        }

        public override void Call()
        {
            // this assumes doubles are pushed in least significant most significant order
            Stack.Pop();
        }
    }
}
