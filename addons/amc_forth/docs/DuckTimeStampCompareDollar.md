# DUCKTIMESTAMPCOMPARE$ &emsp; (DuckTimeStampCompareDollar)
Compares two Timestamps, both of which must be string variables and in the ISO format: YYYY-MM-DD hh:mm:ss.<br/>NOTE: 'comp' is a string variable and can be one of '==', '<', '<=', '>', '>=' or '<>'.<br/>NOTE1: The comparison is as follows: timestamp1 < timestamp2.<br/>NOTE2: This ignores any microseconds and time zones.<br/>Example usage: timestamp1 timestamp2 comp DUCKTIMESTAMPCOMPARE$
* ( timestamp1 timestamp2 comp -- flag )
* [Source Code](../words/duckdb/DuckTimeStampCompareDollar.cs)
* Execution Tokens: 1328215371 (interpreted) and 791344459 (compiled)


[BACK](builtins.md#DuckTimeStampCompareDollar)
