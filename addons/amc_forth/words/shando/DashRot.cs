using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class DashRot : Words
    {
        public DashRot(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "-ROT";
            Description = "Rotate the top three items on the stack twice."
                + " Example usage: 5 6 7 -ROT";
            StackEffect = "( x1 x2 x3 -- x3 x1 x2 )";
        }

        public override void Call()
        {
            var t = Stack.DataStack[Stack.DsP + 2];
            Stack.DataStack[Stack.DsP + 2] = Stack.DataStack[Stack.DsP];
            Stack.DataStack[Stack.DsP] = Stack.DataStack[Stack.DsP + 1];
            Stack.DataStack[Stack.DsP + 1] = t;
        }
    }
}
