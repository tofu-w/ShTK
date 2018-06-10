using ShTK.Divisions;
using ShTK.Graphics;
using ShTK.Graphics.Drawing;
using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Tests.Overhead
{
    public class Header : Division
    {
        Spritefont font;

        public Header()
        {
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            Scale = new Vector2(TestApp.ScreenBounds.Width, 50);
            Fill = true;
            Colour = Color4.Yellow;

            Layout = new Drawable[]
            {
                
                font = new Spritefont(@"ShTK_res\font.bmp", new Vector2(32))
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Scale = new Vector2(20),
                    Text = "the munt man will munt all over your dog and shitthe munt man will munt all over your dog and shit",
                    Position = new Vector2 (2, 50)
                }
                
            };
        }
    }
}
