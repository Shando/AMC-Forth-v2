# WITHIN &emsp; (Within)
Perform a comparison of a test value 'n1' | 'u1' with a lower limit 'n2' | 'u2' and an upper limit 'n3' | 'u3', returning 'TRUE' if either ('n2' | 'u2' < 'n3' | 'u3' and ('n2' | 'u2' <= 'n1' | 'u1' and 'n1' | 'u1' < 'n3' | 'u3')) or ('n2' | 'u2' > 'n3' | 'u3' and ('n2' | 'u2' <= 'n1' | 'u1' or 'n1' | 'u1' < 'n3' | 'u3')) is true, returning 'FALSE' otherwise.<br/>NOTE: An ambiguous condition exists if 'n1' | 'u1', 'n2' | 'u2', and 'n3' | 'u3' are not all the same type.<br/>Example usage: 15 10 100 WITHIN
* ( test low high -- flag )
* [Source Code](../words/shando/Within.cs)
* Execution Tokens: 1479023640 (interpreted) and 942152728 (compiled)


[BACK](builtins.md#Within)
