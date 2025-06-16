using Godot;

// Forth DuckDb word set

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckDbSet : RefCounted
    {
        public DuckCloseDb DuckCloseDb;
        public DuckConvertIntToReal DuckConvertIntToReal;
        public DuckConvertRealToInt DuckConvertRealToInt;
        public DuckDateCompare DuckDateCompare;
        public DuckDateCompareDollar DuckDateCompareDollar;
        public DuckGetRowData DuckGetRowData;
        public DuckGetRowDataDollar DuckGetRowDataDollar;
        public DuckOpenDb DuckOpenDb;
        public DuckOpenDbDollar DuckOpenDbDollar;
        public DuckRunQuery DuckRunQuery;
        public DuckRunQueryDollar DuckRunQueryDollar;
        public DuckTimeCompare DuckTimeCompare;
        public DuckTimeCompareDollar DuckTimeCompareDollar;
        public DuckTimeStampCompare DuckTimeStampCompare;
        public DuckTimeStampCompareDollar DuckTimeStampCompareDollar;

        private const string Wordset = "DUCKDB";

        public DuckDbSet(AMCForth _forth)
        {
            DuckCloseDb = new(_forth, Wordset);
            DuckConvertIntToReal = new(_forth, Wordset);
            DuckConvertRealToInt = new(_forth, Wordset);
            DuckDateCompare = new(_forth, Wordset);
            DuckDateCompareDollar = new(_forth, Wordset);
            DuckGetRowData = new(_forth, Wordset);
            DuckGetRowDataDollar = new(_forth, Wordset);
            DuckOpenDb = new(_forth, Wordset);
            DuckOpenDbDollar = new(_forth, Wordset);
            DuckRunQuery = new(_forth, Wordset);
            DuckRunQueryDollar = new(_forth, Wordset);
            DuckTimeCompare = new(_forth, Wordset);
            DuckTimeCompareDollar = new(_forth, Wordset);
            DuckTimeStampCompare = new(_forth, Wordset);
            DuckTimeStampCompareDollar = new(_forth, Wordset);
        }
    }
}
