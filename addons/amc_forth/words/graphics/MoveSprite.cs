using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class MoveSprite : Words
    {
        public MoveSprite(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "MOVESPRITE";
            Description = 
                "Move the sprite denoted by its spriteid ('id'). If type ('t') = 0 then move by the number of pixels in the 'x' and 'y' directions."
                + " If type ('t') = 1 then move directly to the specified 'x' and 'y' co-ordinates."
                + " Example usage: 24 100 100 1 MOVESPRITE";
            StackEffect = "( id x y t -- )";
        }

        public override void Call()
        {
            int t = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();
            int id = Stack.Pop();

            Forth.fg.CallDeferred("addMoveSprite", id, x, y, t);
        }
    }
}
