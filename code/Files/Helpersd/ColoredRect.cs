using UnityEngine;

namespace Sprites
{
    public class ColoredRect
    {
        private Color _baseColor = Color.blue;

        /// <summary>
        /// Dimensions of the sprite
        /// </summary>
        public Rect Area { get; private set; }

        public Color BaseColor
        {
            get => _baseColor;
            set
            {
                _baseColor = value;
                Sprite.color = _baseColor;
            }
        }

        public CollisionBox Collision => new CollisionBox(Area);

        public FSprite Sprite;

        protected const string TextureName = "Futile_White";

        public ColoredRect(Vector2 position, float width, float height)
        {
            InitializeSprites(position, width, height);
            UpdateArea();
        }

        public virtual void AddSpritesToCamera(RoomCamera cam)
        {
            cam.ReturnFContainer("Foreground").AddChild(Sprite);
        }

        protected virtual void InitializeSprites(Vector2 position, float width, float height)
        {
            //Main body
            Sprite = new(TextureName)
            {
                x = position.x,
                y = position.y,
                width = width,
                height = height,
                color = BaseColor,
            };
        }

        public override string ToString()
        {
            return Area.ToString();
        }

        /// <summary>
        /// This needs to be invoked when the sprite is moved, or has been resized
        /// </summary>
        public virtual void UpdateArea()
        {
            Area = Sprite.GetTextureRectRelativeToContainer();
        }

        public static ColoredRect Create(Vector2 position, float width, float height)
        {
            return new ColoredRect(position, width, height);
        }
    }
}
