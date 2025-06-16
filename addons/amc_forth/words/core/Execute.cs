using Godot;
using static System.Net.Mime.MediaTypeNames;

namespace Forth.Core
{
    [GlobalClass]
    public partial class Execute : Words
    {
        public Execute(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "EXECUTE";
            Description =
                "Remove execution token xt from the stack and perform the execution behavior it identifies.";
            StackEffect = "( xt -- )";
        }

        public override void Call()
        {
            var xt = Stack.Pop();

            if (IsBuiltInXt(xt))
            {
                // this xt identifies a built-in function
                CallXt(xt);
            }
            else if (xt >= Map.DictStart && xt < Map.DictTop)
            {
                //Forth.EmitSignal("TerminalOut", xt.ToString() + Terminal.CRLF);
                // this xt (probably) identifies an address in the dictionary
                // save the current ip
                Forth.PushIp();
                // this is a physical address of an xt
                Forth.DictIp = xt;
                // push the xt
                Stack.Push(Forth.Ram.GetInt(xt));
                // recurse down a layer
                Call();
                // restore our ip
                Forth.PopIp();
            }
            else
            {
                Forth.Util.RprintError(" Invalid execution token (EXECUTE)");
            }
        }
    }
}
