# DUCKOPENDB$ &emsp; (DuckOpenDbDollar)
Opens the database, 'db' (a string variable).<br/>NOTE: The database can be opened in Read Only mode by setting 'ro' to 0, otherwise, set to 1 for Read and Write access.<br/>NOTE1: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>Example usage: myDB 1 DUCKOPENDB$
* ( db ro -- flag )
* [Source Code](../words/duckdb/DuckOpenDbDollar.cs)
* Execution Tokens: 1145637480 (interpreted) and 608766568 (compiled)


[BACK](builtins.md#DuckOpenDbDollar)
