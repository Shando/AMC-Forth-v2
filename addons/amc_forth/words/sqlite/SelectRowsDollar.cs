using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class SelectRowsDollar : Words
    {
        public SelectRowsDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SELECTROWS$";
            Description =
                "Selects rows from the currently opened database table, 'tbl' (a string variable).<br/>"
                + "The query, 'qry' (a string variable) represents the SQL query, and the list of columns,"
                + " 'cols' (a string variable) must be a comma separated list as per below:<br/>"
                + " colname1, colname2, colname3."
                + "NOTE: The total number of results, u, will be left on the stack.<br/>"
                + "NOTE1: Results can be retrieved using GETROWDATA or GETROWDATA$.<br/>"
                + "Example usage: myTbl myQry myCols SELECTROWS$";
            StackEffect = "( tbl qry cols -- u )";
        }

        public override void Call()
        {
            int a2 = Stack.Pop();               // address of Column List
            int n2 = Forth.Ram.GetInt(a2 + 8);  // curlen of Column List
            int a1 = Stack.Pop();               // address of Query
            int n1 = Forth.Ram.GetInt(a1 + 8);  // curlen of Query
            int a0 = Stack.Pop();               // address of Table Name
            int n0 = Forth.Ram.GetInt(a0 + 8);  // curlen of Table Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);
            string s1 = Forth.Util.StrFromAddrN(a1, n1);
            string s2 = Forth.Util.StrFromAddrN(a2, n2);

            Forth.bg.CallDeferred("selectRows", s0, s1, s2);
        }
    }
}
