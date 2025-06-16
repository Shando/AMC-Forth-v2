using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Spaces : Words
    {
        public Spaces(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SPACES";
            Description = "Display u spaces on the current output device.";
            StackEffect = "( u -- )";
        }

        public override void Call()
        {
            var u = Stack.Pop();

            for (int i = 0; i < u; i++)
            {
                Forth.Util.PrintTerm(Terminal.BL);
            }
        }
    }
}
