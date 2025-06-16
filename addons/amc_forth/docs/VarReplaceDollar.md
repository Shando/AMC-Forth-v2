# VARREPLACE$ &emsp; (VarReplaceDollar)
Replaces the characters in string variable 'var1$' from position start using string variable 'var2$'. This will replace the characters in 'var1$', starting from character 6, with the contents of string variable 'var2$'. NOTE: 'var1$' and 'var2$' must have already been initialised with SET$ before you use this word. NOTE2: A string that doesn't fit in the buffer has any overflow characters discarded. Example usage: myString2 6 myString1 VARREPLACE$.
* ( var2$ start var$ -- )
* [Source Code](../words/shando/VarReplaceDollar.cs)
* Execution Tokens: 1539508942 (interpreted) and 1002638030 (compiled)


[BACK](builtins.md#VarReplaceDollar)
