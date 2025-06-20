using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckRealCompare : Words
    {
        public DuckRealCompare(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKREALCOMPARE";
            Description =
                "Compares two 'real' (i.e. Double, Decimal or Float) numbers, both of which must be string variables.<br/>"
                + "NOTE: 'comp' is a string, created using S\", and can be one of '==', '<', '<=', '>', '>=' or '<>'.<br/>"
                + "NOTE1: The comparison is as follows: real1 < real2.<br/>"
                + "Example usage: real1 real2 comp DUCKREALCOMPARE$";
            StackEffect = "( real1 real2 comp -- flag )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            Forth.CoreWords.Fetch.Call();
            int aC = Stack.Pop();               // address of comparison
            int nC = Forth.Ram.GetInt(aC - 4);  // curlen of comparison

            int d2 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a2 = Stack.Pop();               // address of real2
            int n2 = Forth.Ram.GetInt(a2 - 4);  // curlen of real2

            int d1 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a1 = Stack.Pop();               // address of real1
            int n1 = Forth.Ram.GetInt(a1 - 4);  // curlen of real1

            string sCompare = Forth.Util.StrFromAddrN(aC, nC);
            string real1 = Forth.Util.StrFromAddrN(a1, n1);
            string real2 = Forth.Util.StrFromAddrN(a2, n2);

            Words.bRunning = true;
            Forth.bg.CallDeferred("compareReals", real1, real2, sCompare);
        }
    }
}
