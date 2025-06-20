using Godot;

namespace Forth.DuckDb
{
    [GlobalClass]
    public partial class DuckRunQuery : Words
    {
        public DuckRunQuery(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "DUCKRUNQUERY";
            Description =
                "Runs an SQL query against the currently opened database.<br/>"
                + " The 'qry' must be created using S\".<br/>"
                + " Here are some example queries (see https://duckdb.org/docs/stable/sql/introduction):<br/>"
                + "     CREATE TABLE weather (city VARCHAR, temp_lo INTEGER, temp_hi INTEGER, prcp FLOAT, date DATE);<br/>"
                + "     DROP TABLE tablename;<br/>"
                + "     INSERT INTO weather (city, temp_lo, temp_hi, prcp, date) VALUES ('San Francisco', 43, 57, 0.0, '1994-11-29');<br/>"
                + "     SELECT * FROM weather;<br/>"
                + "     SELECT city, temp_lo, temp_hi, prcp, date FROM weather;<br/>"
                + "     SELECT * FROM weather WHERE city = 'San Francisco' AND prcp > 0.0;<br/>"
                + "     SELECT * FROM weather ORDER BY city, temp_lo;<br/>"
                + "     SELECT DISTINCT city FROM weather ORDER BY city;<br/>"
                + "     SELECT weather.city, weather.temp_lo, weather.temp_hi, weather.prcp, weather.date, cities.lon, cities.lat"
                + "         FROM weather, cities WHERE cities.name = weather.city;"
                + "     SELECT * FROM weather INNER JOIN cities ON weather.city = cities.name;<br/>"
                + "     SELECT * FROM weather LEFT OUTER JOIN cities ON weather.city = cities.name;<br/>"
                + "     UPDATE weather SET temp_hi = temp_hi - 2, temp_lo = temp_lo - 2 WHERE date > '1994-11-28';<br/>"
                + "     DELETE FROM weather WHERE city = 'Hayward';<br/>"
                + "NOTE: DuckDB supports the standard SQL data types INTEGER, SMALLINT, FLOAT, DOUBLE, DECIMAL, CHAR(n), VARCHAR(n), DATE, TIME and TIMESTAMP.<br/>"
                + "NOTE1: DuckDB also supports some non-standard data types, such as: BOOLEAN, TINYINT, UINTEGER, USMALLINT and UTINYINT."
                + " It also supports other types, but these will not work with this implementation.<br/>"
                + "NOTE2: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>"
                + "NOTE3: For Data Definition Language commands, such as CREATE, DROP, ALTER & TRUNCATE, 'u' will always be 0.<br/>"
                + "NOTE4: For Data Query Language commands, such as SELECT, 'u' will be the total number of results."
                + " These can be retrieved using 'u' and GETROWDATA or GETROWDATA$.<br/>"
                + "NOTE5: For Data Manipulation Language commands, such as INSERT, UPDATE and DELETE, 'u' will be the number of affected rows.<br/>"
                + "NOTE6: For Data Control Language and Transaction Control Language commands, such as GRANT, REVOKE, COMMIT, ROLLBACK etc., 'u' will always be 0.<br/>"
                + "Example usage: myQry DUCKRUNQUERY";
            StackEffect = "( qry -- u flag )";
        }

        public override void Call()
        {
            Forth.CoreWords.Fetch.Call();
            int a0 = Stack.Pop();               // address of Query
            int n0 = Forth.Ram.GetInt(a0 - 4);  // curlen of Query

            string s0 = Forth.Util.StrFromAddrN(a0, n0);

            Words.bRunning = true;
            Forth.bg.CallDeferred("runQuery", s0);
        }
    }
}
