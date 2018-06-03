using ShTK.Graphics;
using ShTK.Tests.Overhead;
using ShTK.Divisions;
using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Tests
{
    public class TestApp : App
    {
        Header header;

        public TestApp()
        {
            header = new Header();

            Children = new Drawable[]
            {
                header
            };

        }

        public override void Update()
        {
            base.Update();
        }
    }
}
