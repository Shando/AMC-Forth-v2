using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FLiteral : Words
    {
        public FLiteral(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FLITERAL";
            Description =
                "At execution time, remove the top floating point number from the Floating Point stack and compile into the current definition."
                + " Upon executing 'name', place the floating point number on the top of the Floating Point stack.</br>"
                + "Example usage: third 0.333 FLITERAL";
            StackEffect = "Compile:  ( f -- ), Execute: ( -- f )";
            Immediate = true;
        }

        public override void Call()
        {
            var literal_val = Stack.FPPop();
            // copy the execution token
            Forth.Ram.SetInt(Forth.DictTopP, XtX);
            // store the value
            Forth.Ram.SetFP(Forth.DictTopP + RAM.DCellSize, literal_val);
            Forth.DictTopP += (RAM.DCellSize * 2);
            // two cells up
            // preserve dictionary state
            Forth.SaveDictTop();
        }

        public override void CallExec()
        {
            // execution time functionality of literal
            // return contents of cell after execution token
            Stack.FPPush(Forth.Ram.GetFP(Forth.DictIp + RAM.CellSize));
            // advance the instruction pointer by one to skip over the data
            Forth.DictIp += (RAM.DCellSize * 2);
        }
    }
}
