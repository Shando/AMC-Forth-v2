using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class CharPlus : Words
    {
        public CharPlus(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CHAR+";
            Description = "Add the size in bytes of a character to c_addr1, giving c-addr2.";
            StackEffect = "( c-addr1 -- c-addr2 )";
        }

        public override void Call()
        {
            Stack.Push(1);
            Forth.CoreWords.Plus.Call();
        }
    }
}
