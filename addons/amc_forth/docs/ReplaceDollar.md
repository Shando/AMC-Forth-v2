# REPLACE$ &emsp; (ReplaceDollar)
Replaces the characters in string variable 'var$' from position start using the provided string. NOTE: 'var$' must have already been initialised with SET$ before you use this word. NOTE2: A string that doesn't fit in the buffer has any overflow characters discarded. NOTE3: The replacement string must have been created using S" Example usage: S" London" 6 myVar REPLACE$.
* ( addr u start var$ -- )
* [Source Code](../words/shando/ReplaceDollar.cs)
* Execution Tokens: 1214029157 (interpreted) and 677158245 (compiled)


[BACK](builtins.md#ReplaceDollar)
