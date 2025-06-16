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
                "Creates a table, 'tbl' (a string variable) in the currently opened database."
                + " 'dict' (a string variable) contains a list in the form of:"
                + " {"
                + "    'id': "
                + "    {'data_type': int,"
                + "     'primary_key': true,"
                + "     'not_null': true,"
                + "     'unique': true,"
                + "     'default': SOMEVALUE,"
                + "     'auto_increment': true}"
                + " OTHER COLUMNS GO HERE AND REPEAT THE ABOVE"
                + " }"
                + " NOTE: All fields are optional, except 'data_type' which can be either 'int' or 'text'."
                + " Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation."
                + " Example usage: myTbl myDict CREATETABLE$";
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
