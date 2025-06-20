using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ReplaceSprite : Words
    {
        public ReplaceSprite(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "REPLACESPRITE";
            Description =
                "Replaces the sprite denoted by spriteid ('id1') with the sprite denoted by spriteid ('id2').<br/>"
                + "If using shadow sprites, set 's' to 1, else 0. 'p' should be set to 1 if the sprite is the player character, 0 otherwise.<br/>"
                + "NOTE: If the sprite being replaced is the player character, then the new sprite must become the player character.<br/>"
                + "Example usage: 7 15 0 1 REPLACESPRITE";
            StackEffect = "( id1 id2 s p -- )";
        }

        public override void Call()
        {
            int p = Stack.Pop();
            int s = Stack.Pop();
            int id2 = Stack.Pop();
            int id1 = Stack.Pop();

            Forth.fg.CallDeferred("addReplaceSprite", id1, id2, s, p);
        }
    }
}
