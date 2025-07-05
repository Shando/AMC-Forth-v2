using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FFetch : Words
    {
        public FFetch(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F@";
            Description = "Get the contents of the cell at 'addr'.</br>"
                + "Example usage: 512 F@";
            StackEffect = "(DS: addr -- ) (FP: -- f )";
        }

        public override void Call()
        {
            int addr = Stack.Pop();
            float f = Forth.Ram.GetFP(addr);
            Stack.FPPush(f);
        }
    }
}
