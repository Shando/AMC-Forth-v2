using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class ThreeDup : Words
    {
        public ThreeDup(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "3DUP";
            Description = "Duplicate cell trio x1 x2 x3.<br/>"
                + "Example usage: 5 6 7 3DUP";
            StackEffect = "( x1 x2 x3 -- x1 x2 x3 x1 x2 x3 )";
        }

        public override void Call()
        {
            var x3 = Stack.DataStack[Stack.DsP];
            var x2 = Stack.DataStack[Stack.DsP + 1];
            var x1 = Stack.DataStack[Stack.DsP + 2];
            Stack.Push(x1);
            Stack.Push(x2);
            Stack.Push(x3);
        }
    }
}
