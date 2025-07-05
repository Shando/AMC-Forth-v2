using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FFloatPlus : Words
    {
        public FFloatPlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FLOAT+";
            Description = "Adds the size, in address units, of a floating point number to 'addr'.</br>"
                + "Example usage: FLOAT+";
            StackEffect = "(DS: n -- n )";
        }

        public override void Call()
        {
            int addr = Stack.Pop();
            addr += (RAM.DCellSize * 2);
            Stack.Push(addr);
        }
    }
}
