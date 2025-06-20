using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class LoadSprite : Words
    {
        public LoadSprite(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "LOADSPRITE";
            Description =
                "Load the sprite denoted by sprite id ('id1') with texture id ('id2') and its top left at pixel ('x', 'y'). 'p' should be set to 1"
                + " for the player character, 0 for any character that can interact with the player character, -1 otherwise.<br/>"
                + "Collision size is set by the value of 'cs'. A negative value will reduce the size of the collision area,"
                + " for example, -2 = HALF sprite size, and a positive value will increase the size, for example, 2 = TWICE sprite size."
                + " Therefore a value of 0 will mean the SAME size as the sprite.<br/>"
                + "NOTE: It is best practice to only use multiples that divide into the size of the sprite with no remainder.<br/>"
                + "Example usage: 24 33 0 0 1 -2 LOADSPRITE";
            StackEffect = "( id1 id2 x y p cs -- )";
        }

        public override void Call()
        {
            int cs = Stack.Pop();
            int p = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();
            int id2 = Stack.Pop();
            int id1 = Stack.Pop();

            Forth.fg.CallDeferred("addLoadSprite", id1, id2, x, y, p, cs);
        }
    }
}
