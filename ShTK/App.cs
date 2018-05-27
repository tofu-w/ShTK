using System;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Divisions;
using ShTK.Graphics;
using ShTK.Maths;
using ShTK.Content;

namespace ShTK
{
    public class App : AppWindow
    {
        public Division Drawables;

        public App()
        {
            Drawables = new Division()
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                Scale = new Vector2(ScreenBounds.Width, ScreenBounds.Height),
                Alpha = 1,
                Colour = Color4.White,
                Position = Vector2.Zero,
                Visible = true,
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Drawables.Load();
            Drawables.LoadComplete();

            foreach (IResourceHolder i in Drawables.Children.List)
            {
                i.Load();
                i.LoadComplete();
            }
        }

        public override void Update()
        {
            base.Update();

            Drawables.Update();

            foreach (IUpdatable i in Drawables.Children.List)
                i.Update();
        }

        public override void Draw()
        {
            base.Draw();

            Drawables.Draw();

            foreach (IDrawable i in Drawables.Children.List)
                i.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();

            Drawables.Dispose();
        }
    }
}
