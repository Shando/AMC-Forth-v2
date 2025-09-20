# FSTORE$ &emsp; (FStoreDollar)
Populate the string variable 'var$' with the string representation of the Floating Point number stored on the top of the Floating Point stack.<br/>NOTE: 'var$' must have already been initialised with SET$ before you use this word.<br/>NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>Example usage: var$ FSTORE$
* ( var$ -- )
* [Source Code](../words/floating_point/FStoreDollar.cs)
* Execution Tokens: 1474635900 (interpreted) and 937764988 (compiled)


[BACK](builtins.md#FStoreDollar)
