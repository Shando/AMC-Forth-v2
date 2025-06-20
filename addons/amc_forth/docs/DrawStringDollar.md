# DRAWSTRING$ &emsp; (DrawStringDollar)
Draws the contents of the string variable 'var$' with a foreground colour ('r', 'g', 'b', 'a'), starting at the pixel location stored using AT-XYG. A background colour ('rb', 'gb', 'bb', 'ab') and size ('si') can also be specified.<br/>'si' is a multiple of 20, and must be in the range 1 - 4 (any number less than 1 will be replaced with 1 and, any number greater than 4 will be replaced with 4).<br/>If length ('l') = -1 then the whole string will be printed, irrespective of the value of start ('st'). If 'l' is any other number, then the number of characters starting from start ('st') will be drawn.<br/>NOTE: string variables start at character 0.<br/>NOTE2: if 'st' is greater than the current length of the string, then nothing will be drawn.<br/>NOTE3: if 'st' + 'l' is greater than the current length of the string, then only those characters between 'st' and the current length of the string will be drawn.<br/>NOTE4: If si = 1 then each character will be 20 x 20 pixels in size.<br/>Example usage: 0 0 AT-XYG myVar GET$ -1 0 1 255 0 0 255 0 0 0 255 DRAWSTRING$
* ( var$ GET$ l st si r g b a rb gb bb ab -- )
* [Source Code](../words/graphics/DrawStringDollar.cs)
* Execution Tokens: 1080865006 (interpreted) and 543994094 (compiled)


[BACK](builtins.md#DrawStringDollar)
