using OpenTK;
using System;

namespace ShTK.Graphics
{
    /// <summary>
    /// All the anchors
    /// </summary>
    public enum Anchor
    {
        TopLeft,
        TopCentre,
        TopRight,
        Left,
        Centre,
        Right,
        BottomLeft,
        BottomCentre,
        BottomRight
    }

    public static class Anchors
    {
        /// <summary>
        /// Get a <see cref="Vector2"/> using an <see cref="Anchor"/> and a <see cref="Rectangle"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static Vector2 VectorFromAnchor(Anchor a, Rectangle parent)
        {
            switch (a)
            {
                case Anchor.TopLeft:
                    return new Vector2(parent.Left, parent.Top);

                case Anchor.TopCentre:
                    return new Vector2(parent.Left + parent.Width / 2, parent.Top);

                case Anchor.TopRight:
                    return new Vector2(parent.Right, parent.Top);

                case Anchor.Left:
                    return new Vector2(parent.Left, parent.Top + parent.Height / 2);

                case Anchor.Centre:
                    return new Vector2(parent.Left + parent.Width / 2, parent.Top + parent.Height / 2);

                case Anchor.Right:
                    return new Vector2(parent.Right, parent.Top + parent.Height / 2);

                case Anchor.BottomLeft:
                    return new Vector2(parent.Left, parent.Bottom);

                case Anchor.BottomCentre:
                    return new Vector2(parent.Left + parent.Width / 2, parent.Bottom);

                case Anchor.BottomRight:
                    return new Vector2(parent.Right, parent.Bottom);

                default:
                    return new Vector2(parent.Left, parent.Right);
            }
        }

        /// <summary>
        /// Get a <see cref="Vector2"/> using an <see cref="Anchor"/> and a <see cref="Rectangle"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static Vector2 VectorFromAnchor(Anchor a, RectangleF parent)
        {
            switch (a)
            {
                case Anchor.TopLeft:
                    return new Vector2(parent.Left, parent.Top);

                case Anchor.TopCentre:
                    return new Vector2(parent.Left + parent.Width / 2, parent.Top);

                case Anchor.TopRight:
                    return new Vector2(parent.Right, parent.Top);

                case Anchor.Left:
                    return new Vector2(parent.Left, parent.Top + parent.Height / 2);

                case Anchor.Centre:
                    return new Vector2(parent.Left + parent.Width / 2, parent.Top + parent.Height / 2);

                case Anchor.Right:
                    return new Vector2(parent.Right, parent.Top + parent.Height / 2);

                case Anchor.BottomLeft:
                    return new Vector2(parent.Left, parent.Bottom);

                case Anchor.BottomCentre:
                    return new Vector2(parent.Left + parent.Width / 2, parent.Bottom);

                case Anchor.BottomRight:
                    return new Vector2(parent.Right, parent.Bottom);

                default:
                    return new Vector2(parent.Left, parent.Right);
            }
        }
    }
}
