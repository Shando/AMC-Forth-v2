using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ChangeTexture : Words
    {
        public ChangeTexture(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CHANGESPRITETEXTURE";
            Description = 
                "Change the texture of the sprite denoted by its spriteid ('id') to the texture 'x', where x = 000, 001 etc.."
                + " Example usage: 50 14 CHANGESPRITETEXTURE";
            StackEffect = "( id x -- )";
        }

        public override void Call()
        {
            float x = Stack.Pop();
            int id = Stack.Pop();

            Forth.fg.CallDeferred("updateSpriteTexture", id, x);
        }
    }
}
