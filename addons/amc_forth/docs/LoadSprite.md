# LOADSPRITE &emsp; (LoadSprite)
Load the sprite denoted by sprite id ('id1') with texture id ('id2') and its top left at pixel ('x', 'y'). 'p' should be set to 1 for the player character, 0 for any character that can interact with the player character, -1 otherwise. Collision size is set by the value of 'cs'. A negative value will reduce the size of the collision area, for example, -2 = HALF sprite size, and a positive value will increase the size, for example, 2 = TWICE sprite size. Therefore a value of 0 will mean the SAME size as the sprite. NOTE: It is best practice to only use multiples that divide into the size of the sprite with no remainder. Example usage: 24 33 0 0 1 -2 LOADSPRITE
* ( id1 id2 x y p cs -- )
* [Source Code](../words/graphics/LoadSprite.cs)
* Execution Tokens: 1373180412 (interpreted) and 836309500 (compiled)


[BACK](builtins.md#LoadSprite)
