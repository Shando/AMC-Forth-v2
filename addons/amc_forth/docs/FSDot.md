# FS. &emsp; (FSDot)
Display, in the console, the top number on the floating-point stack using scientific notation <significand><exponent>, where <significand> := [-]<digit>.<digits0> and <exponent> := E[-]<digits>.<br/>NOTE1: This displays with a trailing space automatically.<br/>NOTE2: An error occurs if the value of BASE is not (decimal) ten. This will leave the stack as is.<br/>Example usage: 123456789.123 FS.
* ( f -- )
* [Source Code](../words/floating_point/FSDot.cs)
* Execution Tokens: 1267197836 (interpreted) and 730326924 (compiled)


[BACK](builtins.md#FSDot)
