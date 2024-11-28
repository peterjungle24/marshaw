using UnityEngine;

namespace Sprites
{
    public class VisualizerRect : ColoredRect
    {
        private Color _cornerColor = Color.green;

        public Color CornerColor
        {
            get => _cornerColor;
            set
            {
                _cornerColor = value;
                foreach (FSprite corner in CornerSprites)
                    corner.color = _cornerColor;
            }
        }

        public FSprite[] CornerSprites = new FSprite[4];

        public VisualizerRect(Vector2 position, float width, float height) : base(position, width, height)
        {
        }

        public override void AddSpritesToCamera(RoomCamera cam)
        {
            base.AddSpritesToCamera(cam);

            foreach (FSprite corner in CornerSprites)
                cam.ReturnFContainer("HUD").AddChild(corner);
        }

        protected override void InitializeSprites(Vector2 position, float width, float height)
        {
            base.InitializeSprites(position, width, height);

            //Corners
            for (int i = 0; i < CornerSprites.Length; i++)
            {
                CornerSprites[i] = new FSprite(TextureName)
                {
                    //alpha = 0.24f,
                    width = 10f,
                    height = 10f,
                    color = CornerColor,
                };
            }
        }

        /// <summary>
        /// This needs to be invoked when the MainSprite is moved, or has been resized
        /// </summary>
        public override void UpdateArea()
        {
            base.UpdateArea();

            var corners = CornerSprites;

            //Change corner sprite positions
            corners[0].SetPosition(Area.xMin, Area.yMax);
            corners[1].SetPosition(Area.xMax, Area.yMax);
            corners[2].SetPosition(Area.xMin, Area.yMin);
            corners[3].SetPosition(Area.xMax, Area.yMin);
        }

        public static new VisualizerRect Create(Vector2 position, float width, float height)
        {
            return new VisualizerRect(position, width, height);
        }
    }
}
