using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Allot : Words
    {
        public Allot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "ALLOT";
            Description = "Allocate u bytes of data space beginning at the next location.";
            StackEffect = "( u -- )";
        }

        public override void Call()
        {
            Forth.DictTopP += Stack.Pop();
            Forth.SaveDictTop(); // preserve dictionary state
        }
    }
}
