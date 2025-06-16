using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class ToBody : Words
    {
        public ToBody(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = ">BODY";
            Description =
                "Given a word's execution token, return the address of the start "
                + "of that word's parameter field.";
            StackEffect = "( xt -- a-addr )";
        }

        public override void Call()
        {
            // Note this has no meaning for built-in execution tokens, which
            // have no parameter field.
            var xt = Stack.Pop();

            if (xt >= Map.DictStart && xt < Map.DictTop)
            {
                Stack.Push(xt + RAM.CellSize);
            }
            else
            {
                Forth.Util.RprintError(" Invalid execution token (>BODY)");
            }
        }
    }
}
