using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using ShTK.Maths;

namespace ShTK.Graphics.Drawing
{
    public class Box : Drawable
    {

        public Box()
        {
        }

        public override bool? Visible { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Scale { get; set; }
        public override float Rotation { get; set; }
        public override Anchor Anchor { get; set; }
        public override Anchor Origin { get; set; }
        public override Vector2 Position { get; set; }

        public override void Draw()
        {
            Draw(AppWindow.ScreenBounds);
        }

        public void Draw (Rectangle Viewport)
        {
            if (Visible ?? true)
            {
                GL.Viewport(Viewport.ToSystemDrawing());
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(Colour.R, Colour.G, Colour.B, Alpha);

                GL.Vertex2(AbsolutePosition.X, AbsolutePosition.Y);
                GL.Vertex2(AbsolutePosition.X, AbsolutePosition.Y + Scale.Y);
                GL.Vertex2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y + Scale.Y);
                GL.Vertex2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y);

                GL.End();
            }
        }
    }
}
