# DUCKGETROWDATA$ &emsp; (DuckGetRowDataDollar)
Gets the data returned after calling DUCKRUNQUERY or DUCKRUNQUERY$.<br/>Puts the value at 'row' (an integer value starting at 0 for the first row), and 'col' (a string variable representing the name of the column in the results), from the returned dataset, onto the stack.<br/>NOTE: If 'row' is outside the bounds of the results, or 'col' is not a valid column name, then this will put '-1' on the stack.<br/>NOTE1: If the returned value is an integer or a boolean, then this will put the 'value' of the integer / boolean and '0' on the stack.<br/>NOTE2: If the returned value is a string, date / time, or any type of decimal value, then this will put the 'c-addr' and the 'length' of the string (with dates and decimals being converted to strings), and '1' on the stack.<br/>Example usage: myCol 4 DUCKGETROWDATA$
* ( col row -- -1 ) or ( col row -- value 0 ) or ( col row -- c-addr length 1 )
* [Source Code](../words/duckdb/DuckGetRowDataDollar.cs)
* Execution Tokens: 1278549666 (interpreted) and 741678754 (compiled)


[BACK](builtins.md#DuckGetRowDataDollar)
