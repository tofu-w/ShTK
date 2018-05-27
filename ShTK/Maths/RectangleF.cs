using OpenTK;

namespace ShTK.Maths
{
    public class RectangleF : IRectangle
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;

        public float Left => X;
        public float Right => X + Width;
        public float Top => Y;
        public float Bottom => Y + Height;

        public RectangleF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public RectangleF(Vector2 pos, Vector2 size)
        {
            X = pos.X;
            Y = pos.Y;
            Width = size.X;
            Height = size.Y;
        }

        public RectangleF(float a, float b)
        {
            X = a;
            Y = a;
            Width = b;
            Height = b;
        }

        /// <summary>
        /// Convert to <see cref="Rectangle"/> useful if you want to call <see cref="Rectangle.ToSystemDrawing"/> later
        /// </summary>
        /// <returns></returns>
        public Rectangle ToRectangle()
        {
            return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
        }

        public System.Drawing.Rectangle ToSystemDrawing()
        {
            return new System.Drawing.Rectangle((int)X, (int)Y, (int)Width, (int)Height);
        }

        public Vector2 GetPosition()
        {
            return new Vector2(X, Y);
        }

        public Vector2 GetScale()
        {
            return new Vector2(Width, Height);
        }
    }
}
