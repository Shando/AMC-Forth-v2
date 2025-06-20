# DUCKTIMESTAMPCOMPARE &emsp; (DuckTimeStampCompare)
Compares two Timestamps, both of which must be string variables and in the ISO format: YYYY-MM-DD hh:mm:ss.<br/>NOTE: 'comp' is a string, created using S", and can be one of '==', '<', '<=', '>', '>=' or '<>'.<br/>NOTE1: The comparison is as follows: timestamp1 < timestamp2.<br/>NOTE2: This ignores any microseconds and time zones.<br/>Example usage: timestamp1 timestamp2 comp DUCKTIMESTAMPCOMPARE
* ( timestamp1 timestamp2 comp -- flag )
* [Source Code](../words/duckdb/DuckTimeStampCompare.cs)
* Execution Tokens: 1602055239 (interpreted) and 1065184327 (compiled)


[BACK](builtins.md#DuckTimeStampCompare)
