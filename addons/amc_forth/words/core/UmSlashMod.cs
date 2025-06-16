using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class UmSlashMod : Words
    {
        public UmSlashMod(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "UM/MOD";
            Description =
                "Divide ud by u1, leaving quotient u3 and remainder u2. "
                + "All arguments and result are unsigned.";
            StackEffect = "( ud u1 -- u2 u3 )";
        }

        public override void Call()
        {
            var u1 = (uint)Stack.Pop();
            var ud = Stack.PopDword();
            Stack.Push((int)(ud % u1));
            Stack.Push((int)(ud / u1));
        }
    }
}
