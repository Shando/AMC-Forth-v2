using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class HideSprite : Words
    {
        public HideSprite(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "HIDESPRITE";
            Description = 
                "Hide the sprite denoted by its spriteid ('id')."
                + " Example usage: 55 HIDESPRITE";
            StackEffect = "( id -- )";
        }

        public override void Call()
        {
            int id = Stack.Pop();

            Forth.fg.CallDeferred("hideSprite", id);
        }
    }
}
