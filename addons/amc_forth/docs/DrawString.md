# DRAWSTRING &emsp; (DrawString)
Draws the string of characters of length ('l'), denoted by their ASCII codes, with a foreground colour ('r', 'g', 'b', 'a'), starting at the pixel location stored using AT-XYG.<br/>A background colour ('rb', 'gb', 'bb', 'ab') and size ('s') can also be specified.<br/>'s' is a multiple of 20, and must be in the range 1 - 4 (any number less than 1 will be replaced with 1 and, any number greater than 4 will be replaced with 4).<br/>NOTE: If s = 1 then each character will be 20 x 20 pixels.Example usage: 0 0 AT-XY 65 66 67 68 69 70 6 1 255 0 0 255 0 0 0 DRAWSTRING
* ( [SEQUENCE OF CHARS] l s r g b a rb gb bb ab -- )
* [Source Code](../words/graphics/DrawString.cs)
* Execution Tokens: 1171570570 (interpreted) and 634699658 (compiled)


[BACK](builtins.md#DrawString)
