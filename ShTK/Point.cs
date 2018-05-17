using OpenTK;

namespace ShTK
{
    public class Point
    {
        public int X;
        public int Y;

        public Point(int a)
        {
            X = a;
            Y = a;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(System.Drawing.Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public System.Drawing.Point ToSystemDrawing()
        {
            return new System.Drawing.Point(X, Y);
        }

        /// <summary>
        /// TEMPORARY will move over to a vector2 class created in ShTK
        /// </summary>
        /// <returns></returns>
        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }
    }
}
