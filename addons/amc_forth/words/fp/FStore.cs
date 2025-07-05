using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FStore : Words
    {
        public FStore(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "F!";
            Description = "Store 'f' in the cell at 'addr'.";
            StackEffect = "(DS: addr -- ) (FP: f -- )";
        }

        public override void Call()
        {
            int addr = Stack.Pop();
            Forth.Ram.SetFP(addr, Stack.FPPop());
        }
    }
}
