# ADD$ &emsp; (AddDollar)
Adds the string denoted by 'addr' (address) and 'len' (length) to string variable 'var$'.<br/>NOTE: 'var$' must have already been initialised with SET$ before you use this word.<br/>NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>Example usage: S" text" name ADD$
* ( addr len var$ -- )
* [Source Code](../words/shando/AddDollar.cs)
* Execution Tokens: 1552014930 (interpreted) and 1015144018 (compiled)


[BACK](builtins.md#AddDollar)
