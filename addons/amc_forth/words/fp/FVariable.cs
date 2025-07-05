using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FVariable : Words
    {
        public FVariable(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FVARIABLE";
            Description =
                "Create a definition for 'name' by reserving 1 FLOATS address units of data space at a float-aligned address.</br>"
                + "Executing 'name' returns the start address of the allocated cells.</br>"
                + "NOTE1: Skips leading space delimiters.</br>"
                + "NOTE2: Parse 'name' delimited by a space.</br>"
                + "Example usage: floatvar FVARIABLE";
            StackEffect = "Compile: ( 'name' -- ), Execute: ( -- addr )";
        }

        public override void Call()
        {
            Forth.CoreWords.Create.Call();
            // make room for one FLOATS
            Forth.DictTopP += 2 * RAM.DCellSize;
            // preserve dictionary state
            Forth.SaveDictTop();
        }
    }
}
