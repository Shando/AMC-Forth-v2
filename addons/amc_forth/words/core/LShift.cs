using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class LShift : Words
    {
        public LShift(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "LSHIFT";
            Description =
                "Perform a logical left shift of u places on x1, giving x2. "
                + "Fill the vacated LSB bits with zero.";
            StackEffect = "(x1 u -- x2 )";
        }

        public override void Call()
        {
            Forth.CoreWords.Swap.Call();
            Stack.Push(Stack.Pop() << Stack.Pop());
        }
    }
}
