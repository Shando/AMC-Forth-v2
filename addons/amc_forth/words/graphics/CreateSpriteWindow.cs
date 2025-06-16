using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class CreateSpriteWindow : Words
    {
        public CreateSpriteWindow(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "CREATESPRITEWINDOW";
            Description = 
                "Create a sub-window where sprites will be visible. 'x' and 'y' are the top left of the window, 'w' and 'h' are the width and the height."
                + " NOTE: If a sprite window is not declared, then sprites will be visible in the entire window."
                + " Example usage: 272 144 256 192 CREATESPRITEWINDOW";
            StackEffect = "( x y w h -- )";
        }

        public override void Call()
        {
            int h = Stack.Pop();
            int w = Stack.Pop();
            int y = Stack.Pop();
            int x = Stack.Pop();

            Forth.fg.CallDeferred("createSpriteWindow", x, y, w, h);
        }
    }
}
