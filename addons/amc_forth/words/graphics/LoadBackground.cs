using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class LoadBackground : Words
    {
        public LoadBackground(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "LOADBACKGROUND";
            Description =
                "Load the background image denoted by its 'id' at position ('x', 'y').<br/>"
                + "For example: 'id' = 1 will load Screen001.png and negative values for 'x' or 'y' will load the background partially offscreen"
                + " (useful for scrolling).<br/>"
                + "NOTE: If 'aa' is set to 0 then AntiAliasing will be OFF, if set to 1 it will be ON.<br/>"
                + "Example usage: 15 -100 0 1 LOADBACKGROUND";
            StackEffect = "( id x y aa -- )";
        }

        public override void Call()
        {
            int aa = Stack.Pop();
            float y = Stack.Pop();
            float x = Stack.Pop();
            int newScreen = Stack.Pop();

            string Format = "000";
            string imagePath = "user://Backgrounds/Screen" + newScreen.ToString(Format) + ".png";

            Forth.bg.CallDeferred("addLoadBG", imagePath, x, y, aa);
        }
    }
}
