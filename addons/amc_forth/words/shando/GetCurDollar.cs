using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class GetCurDollar : Words
    {
        public GetCurDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETCUR$";
            Description = "Gets the current length ('u') of string variable 'var$'.<br/>"
                + "Example usage: myVar GETCUR$";
            StackEffect = "( var$ -- u )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr + 8);
            Stack.Push(curlen);
        }
    }
}