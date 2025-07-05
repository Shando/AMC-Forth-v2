# FE. &emsp; (FEDot)
Display, in the console, the top number on the floating-point stack using engineering notation, where the significand is greater than or equal to 1.0 and less than 1000.0 and the decimal exponent is a multiple of three.<br/>NOTE1: This displays with a trailing space automatically.<br/>NOTE2: An error occurs if the value of BASE is not (decimal) ten. This will leave the stack as is.<br/>Example usage: 123456789.123 FE.
* ( f -- )
* [Source Code](../words/floating_point/FEDot.cs)
* Execution Tokens: 1267197374 (interpreted) and 730326462 (compiled)


[BACK](builtins.md#FEDot)
