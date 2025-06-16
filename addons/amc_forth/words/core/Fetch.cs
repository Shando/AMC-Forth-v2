using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Fetch : Words
    {
        public Fetch(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "@";
            Description = "Get the contents of the cell at a_addr.";
            StackEffect = "( a_addr -- x )";
        }

        public override void Call()
        {
            var ttt = Stack.Pop();
            var iii = Forth.Ram.GetInt(ttt);
            Stack.Push(iii);
            //Stack.Push(Forth.Ram.GetInt(Stack.Pop()));
        }
    }
}
