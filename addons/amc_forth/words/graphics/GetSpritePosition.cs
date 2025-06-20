using Godot;
using Godot.Collections;
using System.Linq;

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class GetSpritePosition : Words
    {
        public Dictionary gdDict;

        public GetSpritePosition(AMCForth forth, string wordset)
            : base(forth, wordset)
        {
            Name = "GETSPRITEPOSITION";
            Description =
                "Gets the position ('x', 'y') of the top left pixel of the sprite denoted by 'id'.<br/>"
                + "Example usage: 15 GETSPRITEPOSITION";
            StackEffect = "( id -- x y )";
        }

        public override void Call()
        {
            int id = (int)Stack.Pop();

            Vector2 pos = new Vector2(-999.0f, -999.0f);

            var dspSprites = Forth.fg.Get("dispSprites");

            Array array = dspSprites.As<Array>();

            if (array.Count() > 0)
            {
                Dictionary dict = (Dictionary)array[0];

                if ((int)dict["id"] == id)
                {
                    SceneTree st = (SceneTree)Engine.GetMainLoop();
                    Array<Node> nd = st.GetNodesInGroup("Sprites");

                    string tN = (string)dict["a"];
                    string tName = tN.Split('/').LastOrDefault();
                    //string tName = tN.Substring(tN.Length - 13);

                    foreach (Node n in nd)
                    {
                        if (n.Name == tName)
                        {
                            Area2D area2D = (Area2D)n;
                            GodotThread.SetThreadSafetyChecksEnabled(false);
                            pos.X = area2D.Position.X;
                            pos.Y = area2D.Position.Y;
                            GodotThread.SetThreadSafetyChecksEnabled(true);
                        }
                    }

                    Stack.Push((int)pos.X);
                    Stack.Push((int)pos.Y);
                }
            }
            else
            {
                Forth.Util.RprintError("Sprite " + id.ToString() + " not found");
            }
        }
    }
}
