using OpenTK;
using OpenTK.Graphics;
using ShTK.Content;

namespace ShTK.Graphics
{
    public interface IDrawable : IBaseDrawable, IResourceHolder
    {

    }

    /// <summary>
    /// <see cref="IDrawable"/> without Load methods from <see cref="IResourceHolder"/>
    /// </summary>
    public interface IBaseDrawable
    {
        void Draw();

        bool Visible { get; }

        float Alpha { get; }

        Vector2 Position { get; set; }
        Vector2 Scale { get; set; }
        float Rotation { get; set; }

        Anchor Anchor { get; set; }
        Anchor Origin { get; set; }

        Color4 Colour { get; }
    }
}
