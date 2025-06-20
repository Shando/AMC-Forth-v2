using Godot;

namespace Forth.Shando
{
    [GlobalClass]
    public partial class VarDollar : Words
    {
        public VarDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "VAR$";
            Description = "Creates an uninitialised string buffer called 'name' of maximum length 'maxlen'.<br/>"
                + "Example usage: 20 VAR$ myString";
            StackEffect = "( maxlen 'name' -- )";
        }

        public override void Call()
        {
            var x = Stack.Pop();                                    // maxlen
            Forth.CoreWords.Create.Call();                          // create variable
            Forth.Ram.SetInt(Forth.DictTopP, Forth.DictTopP + 4);   // store address of 1st character
            Forth.Ram.SetInt(Forth.DictTopP + 4, x);                // store maxlen
            Forth.Ram.SetInt(Forth.DictTopP + 8, 0);                // store curlen
            Forth.DictTopP += x + 3 * RAM.CellSize;                 // make room for maxlen cell(s) + 3 for address, maxlen & curlen
            Forth.SaveDictTop();                                    // preserve dictionary state
        }
    }
}