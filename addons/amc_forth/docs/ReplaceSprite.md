# REPLACESPRITE &emsp; (ReplaceSprite)
Replaces the sprite denoted by spriteid ('id1') with the sprite denoted by spriteid ('id2'). If using shadow sprites, set 's' to 1, else 0. 'p' should be set to 1 if the sprite is the player character, 0 otherwise. NOTE: If the sprite being replaced is the player character, then the new sprite must become the player character. Example usage: 7 15 0 1 REPLACESPRITE
* ( id1 id2 s p -- )
* [Source Code](../words/graphics/ReplaceSprite.cs)
* Execution Tokens: 1524112152 (interpreted) and 987241240 (compiled)


[BACK](builtins.md#ReplaceSprite)
