using Godot;

namespace Forth.FloatingPoint
{
    [GlobalClass]
    public partial class FConstant : Words
    {
        public FConstant(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "FCONSTANT";
            Description =
                "Create a dictionary entry for 'name', associated with floating point constant 'f'."
                + " Executing 'name' places the value on the floating point stack.<br/>"
                + "Example usage: 0.333 CONSTANT third";
            StackEffect = "Compile: ( 'name' f -- ), Execute: ( -- f )";
        }

        public override void Call()
        {
            float init_val = Stack.FPPop();

            if (Forth.CreateDictEntryName() != 0)
            {
                Forth.Ram.SetInt(Forth.DictTopP, XtX); // copy the execution token
                // store the constant
                Forth.Ram.SetFP(Forth.DictTopP + RAM.DCellSize, init_val);
                Forth.DictTopP += (RAM.DCellSize * 2);
                // two cells up
                // preserve dictionary state
                Forth.SaveDictTop();
            }
        }

        public override void CallExec()
        {
            // return contents of cell after execution token
            Stack.FPPush(Forth.Ram.GetFP(Forth.DictIp + RAM.CellSize));
        }
    }
}
