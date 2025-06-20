# ABORT&quot; &emsp; (AbortQuote)
Parse 'ccc' delimited by a " (double quote). Remove 'x1' from the stack. If any bit of 'x1' is not zero, display 'ccc' and perform an implementation-defined abort sequence that includes the function of ABORT.<br/>Example usage: ABORT" Error: Division by zero!"
* Compile: ( "ccc<quote>" -- ) | Run: (i * x x1-- | i * x ) (R: j * x-- | j * x )
* [Source Code](../words/shando/AbortQuote.cs)
* Execution Tokens: 1146445983 (interpreted) and 609575071 (compiled)


[BACK](builtins.md#AbortQuote)
