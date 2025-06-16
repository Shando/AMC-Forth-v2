# DRAWRECTANGLE &emsp; (DrawRectangle)
Draws a rectangle starting at pixel ('x', 'y'), with width ('w1'), height ('h1'), line width ('lw') and fill colour ('r1', 'g1', 'b1', 'a1'). This also draws a second rectangle outside the first with line width ('bw'), and fill colour ('r2', 'g2', 'b2', 'a2'). NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 then it will be ON. Example usage: 100 100 10 10 5 0 255 0 255 0 0 0 0 0 1 DRAWRECTANGLE
* ( x y w h lw r1 g1 b1 a1 bw r2 g2 b2 a2 aa -- )
* [Source Code](../words/graphics/DrawRectangle.cs)
* Execution Tokens: 1478303976 (interpreted) and 941433064 (compiled)


[BACK](builtins.md#DrawRectangle)
