using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckDateCompare : Words
    {
        public DuckDateCompare(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKDATECOMPARE";
            Description =
                "Compares two Dates, both of which must both be string variables and in the ISO format: YYYY-MM-DD.<br/>"
                + "NOTE: 'comp' is a string, created using S\", and can be one of '==', '<', '<=', '>', '>=' or '<>'.<br/>"
                + "NOTE1: The comparison is as follows: date1 < date2.<br/>"
                + "Example usage: date1 date2 S\" <\" DUCKDATECOMPARE";
            StackEffect = "( date1 date2 comp -- flag )";
        }

        public override void Call()
        {
            Thread.Sleep(25);
            Forth.CoreWords.Fetch.Call();
            int aC = Stack.Pop();               // address of comparison
            int nC = Forth.Ram.GetInt(aC - 4);  // curlen of comparison

            int d2 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a2 = Stack.Pop();               // address of date2
            int n2 = Forth.Ram.GetInt(a2 - 4);  // curlen of date2
            
            int d1 = Stack.Pop();
            Forth.ShandoWords.GetDollar.Call();
            int a1 = Stack.Pop();               // address of date1
            int n1 = Forth.Ram.GetInt(a1 - 4);  // curlen of date1

            string sCompare = Forth.Util.StrFromAddrN(aC, nC);
            string date1 = Forth.Util.StrFromAddrN(a1, n1);
            string date2 = Forth.Util.StrFromAddrN(a2, n2);

            Words.bRunning = true;
            Forth.bg.CallDeferred("compareDates", date1, date2, sCompare);
        }
    }
}
