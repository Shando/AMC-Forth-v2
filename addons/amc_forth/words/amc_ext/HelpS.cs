using System;
using Godot;

namespace Forth.AMCExt
{
    [GlobalClass]
    public partial class HelpS : Words
    {
        public HelpS(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "HELPS";
            Description = "Display stack definition for the following Forth word.";
            StackEffect = "( 'name' -- )";
        }

        public override void Call()
        {
            try
            {
                Forth.Util.PrintTerm(
                    " " + Forth.BuiltinFromName(Forth.AMCExtWords.Help.NextWord()).StackEffect
                );
            }
            catch (ArgumentOutOfRangeException e)
            {
                Forth.Util.PrintUnknownWord(e.ParamName);
            }
        }
    }
}
