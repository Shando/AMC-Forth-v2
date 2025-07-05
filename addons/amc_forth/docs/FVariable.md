# FVARIABLE &emsp; (FVariable)
Create a definition for 'name' by reserving 1 FLOATS address units of data space at a float-aligned address.</br>Executing 'name' returns the start address of the allocated cells.</br>NOTE1: Skips leading space delimiters.</br>NOTE2: Parse 'name' delimited by a space.</br>Example usage: floatvar FVARIABLE
* Compile: ( 'name' -- ), Execute: ( -- addr )
* [Source Code](../words/floating_point/FVariable.cs)
* Execution Tokens: 1516185937 (interpreted) and 979315025 (compiled)


[BACK](builtins.md#FVariable)
