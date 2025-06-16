# DUCKTIMECOMPARE$ &emsp; (DuckTimeCompareDollar)
Compares two Times, both of which must be string variables and in the ISO format: hh:mm:ss. 'comp' is a string variable and can be one of '==', '<', '<=', '>', '>=' or '<>'. NOTE: The comparison is as follows: time1 < time2. NOTE2: This ignores any microseconds and time zones. Example usage: time1 time2 comp DUCKTIMECOMPARE$
* ( time1 time2 comp -- flag )
* [Source Code](../words/duckdb/DuckTimeCompareDollar.cs)
* Execution Tokens: 1495772934 (interpreted) and 958902022 (compiled)


[BACK](builtins.md#DuckTimeCompareDollar)
