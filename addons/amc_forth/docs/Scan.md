# SCAN &emsp; (Scan)
 Search the string specified by 'c-addr1' 'u1' for the character specified by 'c'. Skip all characters not equal to 'c'. The result starts with 'c' or is empty.<br/>NOTE: SCAN is limited to single-byte (ASCII) characters.<br/>NOTE1: Use SEARCH to search for multi-byte characters.<br/>Example usage: S" My String" CHAR t SCAN
* ( c-addr1 u1 c -- c-addr2 u2 )
* [Source Code](../words/shando/Scan.cs)
* Execution Tokens: 1552660650 (interpreted) and 1015789738 (compiled)


[BACK](builtins.md#Scan)
