using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class GetMaxDollar : Words
    {
        public GetMaxDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETMAX$";
            Description = "Gets the maximum length of string variable 'var$'.<br/>"
                + "Example usage: myVar GETMAX$";
            StackEffect = "( var$ -- u )";
        }

        public override void Call()
        {
            var addr = Stack.Pop();
            var maxlen = Forth.Ram.GetInt(addr + 4);
            Stack.Push(maxlen);
        }
    }
}