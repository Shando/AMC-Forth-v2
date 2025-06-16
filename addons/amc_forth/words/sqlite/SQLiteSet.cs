using Forth.Sound;
using Godot;

// Forth SQLite word set

namespace Forth.SQLite
{
    [GlobalClass]
    public partial class SQLiteSet : RefCounted
    {
        public CloseDb CloseDb;
        public CreateDb CreateDb;
        public CreateDbDollar CreateDbDollar;
        public CreateTableDollar CreateTableDollar;
        public DeleteRowsDollar DeleteRowsDollar;
        public DropTable DropTable;
        public DropTableDollar DropTableDollar;
        public GetRowData GetRowData;
        public GetRowDataDollar GetRowDataDollar;
        public InsertRowDollar InsertRowDollar;
        public OpenDb OpenDb;
        public OpenDbDollar OpenDbDollar;
        public SelectRowsDollar SelectRowsDollar;
        public UpdateRowsDollar UpdateRowsDollar;

        private const string Wordset = "SQLITE";

        public SQLiteSet(AMCForth _forth)
        {
            CloseDb = new(_forth, Wordset);
            CreateDb = new(_forth, Wordset);
            CreateDbDollar = new(_forth, Wordset);
            CreateTableDollar = new(_forth, Wordset);
            DeleteRowsDollar = new(_forth, Wordset);
            DropTable = new(_forth, Wordset);
            DropTableDollar = new(_forth, Wordset);
            GetRowData = new(_forth, Wordset);
            GetRowDataDollar = new(_forth, Wordset);
            InsertRowDollar = new(_forth, Wordset);
            OpenDb = new(_forth, Wordset);
            OpenDbDollar = new(_forth, Wordset);
            SelectRowsDollar = new(_forth, Wordset);
            UpdateRowsDollar = new(_forth, Wordset);
        }
    }
}
