using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class KeyA : Words
    {
        public KeyA(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "KEY";
            Description = 
                "If a key has been pressed, pushes the key's value ('key') to the stack."
                + " Example usage: KEY";
            StackEffect = "( -- key )";
        }

        public override void Call()
        {
            int key = (int)Forth.main.Get("lastKey");
            Forth.main.Set("lastKey", -1);
            Stack.Push(key);
        }
    }
}
