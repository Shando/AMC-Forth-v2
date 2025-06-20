using Godot;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class AtXYG : Words
    {
        public AtXYG(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "AT-XYG";
            Description =
                "Configure graphics display so next character displayed will appear at column 'x', row 'y' of the graphics display (origin in upper left).<br/>"
                + "NOTE: 'x' must be between 0 and 39 and 'y' must be between 0 and 23, as the default character size is 20 x 20 pixels.<br/>"
                + "Usage example: 0 5 AT-XYG";
            StackEffect = "( x y -- )";
        }

        public override void Call()
        {
            int u2 = Stack.Pop();
            int u1 = Stack.Pop();

            if (u1 < 0 || u1 > 39)
            {
                Forth.Util.RprintError("AT-XYG - x value must be between 0 and 39.");
            }
            else
            {
                if (u2 < 0 || u2 > 23)
                {
                    Forth.Util.RprintError("AT-XYG - y value must be between 0 and 23.");
                }
                else
                {
                    Forth.AtXYG[0] = u1;
                    Forth.AtXYG[1] = u2;
                }
            }
        }
    }
}
