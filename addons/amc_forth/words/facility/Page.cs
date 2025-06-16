using Godot;

namespace Forth.Facility
{
    [GlobalClass]
    public partial class Page : Words
    {
        public Page(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "PAGE";
            Description =
                "Clear the screen and reset cursor position to the upper left corner.";
            StackEffect = "( -- )";
        }

        public override void Call()
        {
            Rect2 size1 = Forth.fg.GetViewportRect();
            Rect2 clearScreenRect = new(0, 0, size1.Size.X, size1.Size.Y);
            Color c = new(0.0f, 0.0f, 0.0f, 1.0f);

            Forth.fg.Set("clearScreenRect", clearScreenRect);
            Forth.fg.Set("clearScreenColour", c);
            Forth.fg.Set("bClearScreen", true);

            Stack.Push(0);
            Forth.CoreWords.Dup.Call();
            Forth.FacilityWords.AtXY.Call();
        }
    }
}
