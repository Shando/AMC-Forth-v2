using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class ScrollBackground : Words
    {
        public ScrollBackground(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "SCROLLBACKGROUND";
            Description =
                "Scroll the background image by setting scroll speed in the 'x' and 'y' directions.<br/>"
                + "NOTE: This speed is in pixels per second.<br/>"
                + "NOTE1: Positive values scroll down and/or right, negative values scroll up and/or left.<br/>"
                + "NOTE2: Setting values of 0 & 0 will stop the scrolling effect.<br/>"
                + "Example usage: 0 8 SCROLLBACKGROUND";
            StackEffect = "( x y -- )";
        }

        public override void Call()
        {
            int y = Stack.Pop();
            int x = Stack.Pop();

            Forth.bg.CallDeferred("addScrollBG", x, y);
        }
    }
}
