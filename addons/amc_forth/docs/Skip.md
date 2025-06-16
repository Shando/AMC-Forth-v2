# SKIP &emsp; (Skip)
 Search the string specified by 'c-addr1' 'u1' for the character specified by 'c'. Skip all characters equal to 'c'. The result is the string minus all occurrences of 'c', or is empty. NOTE: SKIP is limited to single-byte (ASCII) characters. Example usage: S" My String" CHAR A SKIP
* ( c-addr1 u1 c -- c-addr2 u2 )
* [Source Code](../words/shando/Skip.cs)
* Execution Tokens: 1552669628 (interpreted) and 1015798716 (compiled)


[BACK](builtins.md#Skip)
