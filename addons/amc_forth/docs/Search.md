# SEARCH &emsp; (Search)
Search the string specified by 'c-addr1' 'u1' for the string specified by 'c-addr2' 'u2'. If 'flag' is 'TRUE', a match was found at 'c-addr3' with 'u3' characters remaining. If 'flag' is 'FALSE' there was no match, and 'c-addr3' is 'c-addr1' and 'u3' is 'u1'. NOTE: the two strings can both be string variables, or can be one string variable and one string created using S".     However, they cannot be two strings created using S". Example usage: myVar1 GET$ S" h" SEARCH
* ( c-addr1 u1 c-addr2 u2 -- c-addr3 u3 flag )
* [Source Code](../words/shando/Search.cs)
* Execution Tokens: 1317066267 (interpreted) and 780195355 (compiled)


[BACK](builtins.md#Search)
