# SET$ &emsp; (SetDollar)
Stores the string denoted by 'addr' (address) and 'len' (length) in string variable 'var$'. NOTE: This will overwrite the existing string in 'var$', but may leave some characters if 'len' is less than     the current length of the stored string. NOTE2: A string that doesn't fit in the buffer has any overflow characters discarded. Example usage: S" My String" myVar SET$
* ( addr len var$ -- )
* [Source Code](../words/shando/SetDollar.cs)
* Execution Tokens: 1552663413 (interpreted) and 1015792501 (compiled)


[BACK](builtins.md#SetDollar)
