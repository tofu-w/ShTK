using System.Drawing;

namespace ShTK
{
    public class Rectangle
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        public int Left => X;
        public int Right => X + Width;
        public int Top => Y;
        public int Bottom => Y + Height;

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Rectangle(float x, float y, float width, float height)
        {
            X = (int)x;
            Y = (int)y;
            Width = (int)width;
            Height = (int)height;
        }

        public Rectangle(Point pos, Point size)
        {
            X = pos.X;
            Y = pos.Y;
            Width = size.X;
            Height = size.Y;
        }

        public Rectangle(int a, int b)
        {
            X = a;
            Y = a;
            Width = b;
            Height = b;
        }

        public Rectangle(System.Drawing.Rectangle rect)
        {
            X = rect.X;
            Y = rect.Y;
            Width = rect.Width;
            Height = rect.Height;
        }

        /// <summary>
        /// Returns a <see cref="System.Drawing.Rectangle"/>. Use ONLY for low level OpenGL calls
        /// You should not be needing to use this for general use.
        /// </summary>
        /// <returns></returns>
        public System.Drawing.Rectangle ToSystemDrawing()
        {
            return new System.Drawing.Rectangle(X, Y, Width, Height);
        }

        public RectangleF ToRectangleF()
        {
            return new RectangleF((float)X, (float)Y, (float)Width, (float)Height);
        }
    }
}
