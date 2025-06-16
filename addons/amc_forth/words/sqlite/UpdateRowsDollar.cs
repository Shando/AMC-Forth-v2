using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class UpdateRowsDollar : Words
    {
        public UpdateRowsDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "UPDATEROWS$";
            Description =
                "Updates rows in the table, 'tbl' (a string variable), in the currently opened database."
                + " The query, 'qry' (a string variable) represents the SQL query, and the column data list,"
                + " 'cols' (a string variable) must be similar to the below:"
                + " {'col1name': 'text goes here', 'col3name': 15, 'col4name': 'more text'}"
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: myTbl myQry myCols UPDATEROWS$";
            StackEffect = "( tbl qry cols -- flag )";
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

            Forth.bg.CallDeferred("updateRows", s0, s1, s2);
        }
    }
}
