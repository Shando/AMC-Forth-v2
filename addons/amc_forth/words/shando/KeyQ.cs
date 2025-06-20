using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class KeyQ : Words
    {
        public KeyQ(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "KEY?";
            Description =
                "If a key has been pressed, pushes 'TRUE' to the stack, else pushes 'FALSE'.<br/>"
                + "Example usage: KEY?";
            StackEffect = "( -- flag )";
        }

        public override void Call()
        {
            int key = (int)Forth.main.Get("lastKey");

            if (key > -1)
                Stack.Push(AMCForth.True);
            else
                Stack.Push(AMCForth.False);
        }
    }
}
