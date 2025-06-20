using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckTimeStampCompare : Words
    {
        public DuckTimeStampCompare(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKTIMESTAMPCOMPARE";
            Description =
                "Compares two Timestamps, both of which must be string variables and in the ISO format: YYYY-MM-DD hh:mm:ss.<br/>"
                + "NOTE: 'comp' is a string, created using S\", and can be one of '==', '<', '<=', '>', '>=' or '<>'.<br/>"
                + "NOTE1: The comparison is as follows: timestamp1 < timestamp2.<br/>"
                + "NOTE2: This ignores any microseconds and time zones.<br/>"
                + "Example usage: timestamp1 timestamp2 comp DUCKTIMESTAMPCOMPARE";
            StackEffect = "( timestamp1 timestamp2 comp -- flag )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            Forth.CoreWords.Fetch.Call();
            int aC = Stack.Pop();               // address of comparison
            int nC = Forth.Ram.GetInt(aC - 4);  // curlen of comparison

            int d2 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a2 = Stack.Pop();               // address of timestamp2
            int n2 = Forth.Ram.GetInt(a2 - 4);  // curlen of timestamp2

            int d1 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a1 = Stack.Pop();               // address of timestamp1
            int n1 = Forth.Ram.GetInt(a1 - 4);  // curlen of timestamp1

            string sCompare = Forth.Util.StrFromAddrN(aC, nC);
            string timestamp1 = Forth.Util.StrFromAddrN(a1, n1);
            string timestamp2 = Forth.Util.StrFromAddrN(a2, n2);

            Words.bRunning = true;
            Forth.bg.CallDeferred("compareTimestamps", timestamp1, timestamp2, sCompare);
        }
    }
}
