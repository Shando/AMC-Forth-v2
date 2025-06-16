using Forth.Core;
using Godot;

// Forth GRAPHICS word set

namespace Forth.Graphics
{
    [GlobalClass]
    public partial class GraphicsSet : RefCounted
    {
        public AtXYG AtXYG;
        public ChangeTexture ChangeTexture;
        public DrawLine DrawLine;
        public SetPixel SetPixel;
        public GetPixel GetPixel;
        public ClearScreen ClearScreen;
        public ClearScreenPartial ClearScreenPartial;
        public CreateSpriteWindow CreateSpriteWindow;
        public DrawCircle DrawCircle;
        public DrawArc DrawArc;
        public DrawRectangle DrawRectangle;
        public DrawString DrawString;
        public DrawStringDollar DrawStringDollar;
        public LoadSprite LoadSprite;
        public MoveSprite MoveSprite;
        public RemoveSprite RemoveSprite;
        public ShowSprite ShowSprite;
        public HideSprite HideSprite;
        public ClearBackground ClearBackground;
        public LoadBackground LoadBackground;
        public ScrollBackground ScrollBackground;
        public GetSpritePosition GetSpritePosition;
        public ReplaceSprite ReplaceSprite;
        public GetTimeMS GetTimeMS;
        public GetTimeS GetTimeS;

        private const string Wordset = "GRAPHICS";

        public AMCForth forth;

        public GraphicsSet(AMCForth _forth)
        {
            AtXYG = new(_forth, Wordset);
            ChangeTexture = new(_forth, Wordset);
            DrawLine = new(_forth, Wordset);
            SetPixel = new(_forth, Wordset);
            GetPixel = new(_forth, Wordset);
            ClearScreen = new(_forth, Wordset);
            ClearScreenPartial = new(_forth, Wordset);
            CreateSpriteWindow = new(_forth, Wordset);
            DrawCircle = new(_forth, Wordset);
            DrawArc = new(_forth, Wordset);
            DrawRectangle = new(_forth, Wordset);
            DrawString = new(_forth, Wordset);
            DrawStringDollar = new(_forth, Wordset);
            LoadSprite = new(_forth, Wordset);
            MoveSprite = new(_forth, Wordset);
            RemoveSprite = new(_forth, Wordset);
            ShowSprite = new(_forth, Wordset);
            HideSprite = new(_forth, Wordset);
            ClearBackground = new(_forth, Wordset);
            LoadBackground = new(_forth, Wordset);
            ScrollBackground = new(_forth, Wordset);
            GetSpritePosition = new(_forth, Wordset);
            ReplaceSprite = new(_forth, Wordset);
            GetTimeMS = new(_forth, Wordset);
            GetTimeS = new(_forth, Wordset);

            forth = _forth;
        }
    }
}
