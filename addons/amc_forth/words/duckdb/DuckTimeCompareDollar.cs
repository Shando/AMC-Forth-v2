using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckTimeCompareDollar : Words
    {
        public DuckTimeCompareDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKTIMECOMPARE$";
            Description =
                "Compares two Times, both of which must be string variables and in the ISO format: hh:mm:ss."
                + " NOTE: 'comp' is a string variable and can be one of '==', '<', '<=', '>', '>=' or '<>'."
                + " NOTE1: The comparison is as follows: time1 < time2."
                + " NOTE2: This ignores any microseconds and time zones."
                + " Example usage: time1 time2 comp DUCKTIMECOMPARE$";
            StackEffect = "( time1 time2 comp -- flag )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            int c = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int aC = Stack.Pop();               // address of comparison
            int nC = Forth.Ram.GetInt(aC - 4);  // curlen of comparison

            int d2 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a2 = Stack.Pop();               // address of time2
            int n2 = Forth.Ram.GetInt(a2 - 4);  // curlen of time2

            int d1 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a1 = Stack.Pop();               // address of time1
            int n1 = Forth.Ram.GetInt(a1 - 4);  // curlen of time1

            string sCompare = Forth.Util.StrFromAddrN(aC, nC);
            string time1 = Forth.Util.StrFromAddrN(a1, n1);
            string time2 = Forth.Util.StrFromAddrN(a2, n2);

            Words.bRunning = true;
            Forth.bg.CallDeferred("compareDates", time1, time2, sCompare);
        }
    }
}
