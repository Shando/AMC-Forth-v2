using Godot;
using System.Threading;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckDateCompareDollar : Words
    {
        public DuckDateCompareDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKDATECOMPARE$";
            Description =
                "Compares two Dates, both of which must be string variables."
                + " 'comp' is a string variable and can be one of '==', '<', '<=', '>', '>=' or '<>'."
                + " NOTE: The comparison is as follows: date1 < date2."
                + " Example usage: date1 date2 comp DUCKDATECOMPARE$";
            StackEffect = "( date1 date2 comp -- flag )";
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
