using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ShowSprite : Words
    {
        public ShowSprite(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SHOWSPRITE";
            Description =
                "Show the sprite denoted by its spriteid ('id')."
                + " For example: id = 7 will show user://Sprites/Sprite007.png."
                + " Example usage: 7 SHOWSPRITE";
            StackEffect = "( id -- )";
        }

        public override void Call()
        {
            int id = Stack.Pop();

            Forth.fg.CallDeferred("showSprite", id);
        }
    }
}
