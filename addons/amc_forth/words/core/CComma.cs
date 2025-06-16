using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class CComma : Words
    {
        public CComma(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "C,";
            Description = "Reserve one byte of data space and store char in the byte.";
            StackEffect = "( char -- )";
        }

        public override void Call()
        {
            Forth.Ram.SetByte(Forth.DictTopP, Stack.Pop());
            Forth.DictTopP += 1;
            Forth.SaveDictTop(); // preserve dictionary state
        }
    }
}
