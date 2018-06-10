using ShTK.Graphics;
using ShTK.Tests.Overhead;
using ShTK.Graphics.Drawing;
using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Tests
{
    public class TestApp : App
    {
        Header header;
        Box box;

        public TestApp()
        {
            header = new Header();

            Children = new Drawable[]
            {
                header,
                box = new Box ()
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2 (100)
                }
            };
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
