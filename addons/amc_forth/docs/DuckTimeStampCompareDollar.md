# DUCKTIMESTAMPCOMPARE$ &emsp; (DuckTimeStampCompareDollar)
Compares two Timestamps, both of which must be string variables and in the ISO format: YYYY-MM-DD hh:mm:ss. 'comp' is a string variable and can be one of '==', '<', '<=', '>', '>=' or '<>'. NOTE: The comparison is as follows: timestamp1 < timestamp2. NOTE2: This ignores any microseconds and time zones. Example usage: timestamp1 timestamp2 comp DUCKTIMESTAMPCOMPARE$
* ( timestamp1 timestamp2 comp -- flag )
* [Source Code](../words/duckdb/DuckTimeStampCompareDollar.cs)
* Execution Tokens: 1328215371 (interpreted) and 791344459 (compiled)


[BACK](builtins.md#DuckTimeStampCompareDollar)
