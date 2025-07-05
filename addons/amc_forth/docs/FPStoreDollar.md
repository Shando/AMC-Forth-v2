# FPSTORE$ &emsp; (FPStoreDollar)
Populate string variable 'var$' with the string representation of the Floating Point number stored on the top of the Floating Point stack.<br/>NOTE: 'var$' must have already been initialised with SET$ before you use this word.<br/>NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>Usage example: var$ FSTORE$
* ( var$ -- )
* [Source Code](../words/floating_point/FPStoreDollar.cs)
* Execution Tokens: 1268738604 (interpreted) and 731867692 (compiled)


[BACK](builtins.md#FPStoreDollar)
