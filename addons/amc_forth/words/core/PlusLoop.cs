using Godot;

namespace Forth.Core
{
    [GlobalClass]
    public partial class PlusLoop : Words
    {
        public PlusLoop(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "+LOOP";
            Description =
                "Like LOOP but increment the index by the specified signed value n. After "
                + "incrementing, if the index crossed the boundary between the limit - 1 "
                + "and the limit, the loop is terminated.";
            StackEffect = "( dest orig n -- )";
            Immediate = true;
        }

        public override void Call()
        {
            Forth.Ram.SetInt(Forth.DictTopP, XtX);

            // Check for any orig links
            while (!Forth.LcfIsEmpty())
            {
                // destination is on top of the back link
                Forth.Ram.SetInt(Forth.LcfPop(), Forth.DictTopP + RAM.CellSize);
            }

            // The link back
            Forth.Ram.SetInt(Forth.DictTopP + RAM.CellSize, Forth.CfPopDest());
            Forth.DictTopP += RAM.DCellSize;
            // two cells up and done
            Forth.SaveDictTop(); // preserve dictionary state
        }

        public override void CallExec()
        {
            // pull out the increment
            var n = Stack.Pop();
            Forth.CoreExtWords.TwoRFrom.Call(); // Move two loop params to the data stack.
            var i = (long)Stack.Pop(); // current index
            var limit = (long)Stack.Pop(); // limit value
            var above_before = i >= limit;
            var next_i = i + n;
            var above_after = next_i >= limit;

            if (above_before != above_after)
            {
                // loop is satisfied
                Forth.DictIp += RAM.CellSize;
            }
            else
            {
                // loop must continue
                Stack.Push((int)limit);
                // original limit
                Stack.Push((int)next_i);
                // not matched, branch back, placing loop parameters on the return stack
                Forth.CoreExtWords.TwoToR.Call();
                Forth.DictIp = Forth.Ram.GetInt(Forth.DictIp + RAM.CellSize);
            }
        }
    }
}
