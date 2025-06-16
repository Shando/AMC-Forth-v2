# DUCKTIMECOMPARE &emsp; (DuckTimeCompare)
Compares two Times, both of which must be string variables and in the ISO format: hh:mm:ss. 'comp' is a string, created using S", and can be one of '==', '<', '<=', '>', '>=' or '<>'. NOTE: The comparison is as follows: time1 < time2. NOTE2: This ignores any microseconds and time zones. Example usage: time1 time2 S" <" DUCKTIMECOMPARE
* ( time1 time2 comp -- flag )
* [Source Code](../words/duckdb/DuckTimeCompare.cs)
* Execution Tokens: 1167874722 (interpreted) and 631003810 (compiled)


[BACK](builtins.md#DuckTimeCompare)
