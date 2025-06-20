using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class Bounds : Words
    {
        public Bounds(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "BOUNDS";
            Description =
                "Given a memory block represented by starting address 'addr' and length 'u' in address units, produce"
                + " the end address 'addr' + 'u' and the start address in the right order.<br/>"
                + "Example usage: 256 10 BOUNDS";
            StackEffect = "( addr u -- addr+u addr )";
        }

        public override void Call()
        {
            var u = Stack.Pop();
            var a1 = Stack.Pop();

            Stack.Push(a1 + u);
            Stack.Push(a1);
        }
    }
}
