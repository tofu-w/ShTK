using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Graphics
{
    /// <summary>
    /// Anything that can load and draw is considered a drawable
    /// </summary>
    public abstract class Drawable : IDrawable
    {
        public abstract bool Visible { get; set; }
        public abstract float Alpha { get; set; }
        public abstract Color4 Colour { get; set; }
        public abstract Vector2 Position { get; set; }
        public abstract Vector2 Scale { get; set; }
        public abstract float Rotation { get; set; }
        public abstract Anchor Anchor { get; set; }
        public abstract Anchor Origin { get; set; }

        public RectangleF Rectangle => new RectangleF(Position, Scale);

        public Drawable() { }

        public virtual void Load() { }

        public virtual void LoadComplete() { }

        public virtual void Draw() { }
    }
}
