# /STRING &emsp; (SlashString)
Adjust the character string at 'c-addr1' by 'n' characters. The resulting character string, specified by 'c-addr2' 'u2', begins at 'c-addr1' plus 'n' characters and is 'u1' minus 'n' characters long. Example usage: S" Test String" 5 /STRING
* ( c-addr1 u1 n -- c-addr2 u2 )
* [Source Code](../words/shando/SlashString.cs)
* Execution Tokens: 1298871115 (interpreted) and 762000203 (compiled)


[BACK](builtins.md#SlashString)
