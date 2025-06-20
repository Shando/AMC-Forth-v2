using Godot;

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class CreateTableDollar : Words
    {
        public CreateTableDollar(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CREATETABLE$";
            Description =
                "Creates a table, 'tbl' (a string variable) in the currently opened database.<br/>"
                + "'dict' (a string variable) contains a list in the form of:<br/>"
                + "{<br/>"
                + "    'id': <br/>"
                + "    {'data_type': int,<br/>"
                + "     'primary_key': true,<br/>"
                + "     'not_null': true,<br/>"
                + "     'unique': true,<br/>"
                + "     'default': SOMEVALUE,<br/>"
                + "     'auto_increment': true}<br/>"
                + " OTHER COLUMNS GO HERE AND REPEAT THE ABOVE<br/>"
                + "}<br/>"
                + "NOTE: All fields are optional, except 'data_type' which can be either 'int' or 'text'.<br/>"
                + "NOTE1: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>"
                + "Example usage: myTbl myDict CREATETABLE$";
            StackEffect = "( tbl dict -- flag )";
        }

        public override void Call()
        {
            int a1 = Stack.Pop();                   // address of Dictionary
            int n1 = Forth.Ram.GetInt(a1 + 8);      // curlen of Dictionary
            int a0 = Stack.Pop();                   // address of Table Name
            int n0 = Forth.Ram.GetInt(a0 + 8);      // curlen of Table Name

            string s0 = Forth.Util.StrFromAddrN(a0, n0);
            string s1 = Forth.Util.StrFromAddrN(a1, n1);

            Forth.bg.CallDeferred("createTable", s0, s1);
        }
    }
}
