using ShTK.Divisions;
using ShTK.Graphics;
using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Tests.Overhead
{
    public class Header : Division
    {
        public Header()
        {
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            Scale = new Vector2(TestApp.ScreenBounds.Width, 50);
            Fill = true;
            Colour = new Color4(0.61f, 0.61f, 0.61f, 1f);

            Layout = new Drawable[] 
            {

            };
        }
    }
}
