using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class DeleteRowsDollar : Words
    {
        public DeleteRowsDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DELETEROWS$";
            Description =
                "Deletes rows in the table, 'tbl' (a string variable), in the currently opened database."
                + " The SQL query, 'qry' (a string variable) contains the relevant SQL query."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: myTbl myQry DELETEROWS$";
            StackEffect = "( tbl qry -- flag )";
        }

        public override void Call()
        {
            int a1 = Stack.Pop();               // address of Query
            int n1 = Forth.Ram.GetInt(a1 + 8);  // curlen of Query
            int a0 = Stack.Pop();               // address of Table Name
            int n0 = Forth.Ram.GetInt(a1 + 8);  // curlen of Table Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);
            string s1 = Forth.Util.StrFromAddrN(a1, n1);

            Forth.bg.CallDeferred("deleteRows", s0, s1);
        }
    }
}
