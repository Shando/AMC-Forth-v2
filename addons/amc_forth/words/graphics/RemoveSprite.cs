using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class RemoveSprite : Forth.Words
    {
        public RemoveSprite(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "REMOVESPRITE";
            Description = 
                "Remove the sprite denoted by its spriteid ('id')."
                + " For example: id = 77, spriteID = Sprite077.png"
                + " Example usage: 5 REMOVESPRITE";
            StackEffect = "( id -- )";
        }

        public override void Call()
        {
            int id = Stack.Pop();

            Forth.fg.CallDeferred("addRemoveSprite", id);
        }
    }
}
