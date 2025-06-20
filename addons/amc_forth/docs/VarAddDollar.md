# VARADD$ &emsp; (VarAddDollar)
Adds the string variable 'var2$' to the string variable 'var1$'.<br/>NOTE: 'var1$' and 'var2$' must have already been initialised with SET$ before you use this word.<br/>NOTE1: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>Example usage: myString2 myString1 ADD$.
* ( var2$ var1$ -- )
* [Source Code](../words/shando/VarAddDollar.cs)
* Execution Tokens: 1566572347 (interpreted) and 1029701435 (compiled)


[BACK](builtins.md#VarAddDollar)
