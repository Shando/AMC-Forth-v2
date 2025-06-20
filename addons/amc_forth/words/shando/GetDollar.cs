using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class GetDollar : Words
    {
        public GetDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GET$";
            Description = "Gets the address ('addr') and current length ('len') of string variable 'var$'.<br/>"
                + "Example usage: myVar GET$";
            StackEffect = "( var$ -- addr len )";
        }

        public override void Call()
        {
            Forth.CoreWords.Fetch.Call();
            Forth.CoreWords.Dup.Call();
            var addr = Stack.Pop();
            var curlen = Forth.Ram.GetInt(addr - 4);
            Stack.Push(curlen);
        }
    }
}