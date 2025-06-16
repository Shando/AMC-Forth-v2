# LOADBACKGROUND &emsp; (LoadBackground)
Load the background image denoted by its 'id' at position ('x', 'y'). For example: 'id' = 1 will load Screen001.png and negative values for 'x' or 'y' will load the background partially offscreen (useful for scrolling). NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 it will be ON. Example usage: 15 -100 0 1 LOADBACKGROUND
* ( id x y -- )
* [Source Code](../words/graphics/LoadBackground.cs)
* Execution Tokens: 1219060293 (interpreted) and 682189381 (compiled)


[BACK](builtins.md#LoadBackground)
