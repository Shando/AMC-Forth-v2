# DUCKOPENDB &emsp; (DuckOpenDb)
Opens the database, 'db' (a string created using S").<br/>NOTE: The database can be opened in Read Only mode by setting 'ro' to 0, otherwise, set to 1 for Read and Write access.<br/>NOTE1: Puts 'TRUE' or 'FALSE' on the stack depending on the success of the operation.<br/>Example usage: S" myDB" 1 DUCKOPENDB
* ( db ro -- flag )
* [Source Code](../words/duckdb/DuckOpenDb.cs)
* Execution Tokens: 1450103236 (interpreted) and 913232324 (compiled)


[BACK](builtins.md#DuckOpenDb)
