# F.$ &emsp; (FDotDollar)
Saves the top number on the floating-point stack to the denoted string variable 'var$' using fixed-point notation: [-]<digits>.<digits>.<br/>NOTE1: This displays with a trailing space automatically.<br/>NOTE2: An error occurs if the value of BASE is not (decimal) ten. This will leave the stack as is.<br/>NOTE3: 'var$' must have already been initialised with SET$ before you use this word.<br/>NOTE4: This will overwrite the existing string in 'var$', but may leave some characters if the length of the Floating Point string is less than the current length of the stored string.<br/>NOTE5: A string that doesn't fit in the buffer has any overflow characters discarded.<br/>Example usage: 123456789.123 myVar F.$
* ( f var$ -- )
* [Source Code](../words/floating_point/FDotDollar.cs)
* Execution Tokens: 1267196605 (interpreted) and 730325693 (compiled)


[BACK](builtins.md#FDotDollar)
