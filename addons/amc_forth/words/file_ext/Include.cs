using Godot;

namespace Forth.FileExt
{
    [GlobalClass]
    public partial class Include : Words
    {
        public Include(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "INCLUDE";
            Description =
                "Parse the following word and use as file name with INCLUDED. "
                + "Check user:// first, then res://.";
            StackEffect = "( i*x 'filename' -- j*x )";
        }

        public override void Call()
        {
            Forth.CoreExtWords.ParseName.Call();
            Forth.FileWords.Included.Call();
        }
    }
}
