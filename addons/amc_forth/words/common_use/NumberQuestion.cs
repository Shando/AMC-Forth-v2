using Godot;

namespace Forth.CommonUse
{
    [GlobalClass]
    public partial class NumberQuestion : Words
    {
        public NumberQuestion(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "NUMBER?";
            Description =
                "Attempt to convert a string at c-addr of length u into digits using "
                + "BASE as radix. If a decimal point is found, return a double, otherwise "
                + "return a single, with a flag: 0 = failure, 1 = single, 2 = double.";
            StackEffect = "( c-addr u -- 0 | n 1 | d 2 )";
        }

        public override void Call()
        {
            var radix = Forth.Ram.GetInt(Map.Base);
            var len = Stack.Pop();
            // length of word
            var caddr = Stack.Pop();
            // start of word
            var t = Forth.Util.StrFromAddrN(caddr, len);

            if (t.Contains(".") && Util.IsValidLong(t.Replace(".", ""), radix))
            {
                var t_strip = t.Replace(".", "");
                var temp = Util.ToLong(t_strip, radix);
                Stack.PushDint(temp);
                Stack.Push(2);
            }
            else if (Util.IsValidInt(t, radix))
            {
                var temp = Util.ToInt(t, radix);

                // single-precision
                Stack.Push(temp);
                Stack.Push(1);
            }
            else // nothing we recognize
            {
                Stack.Push(0);
            }
        }
    }
}
