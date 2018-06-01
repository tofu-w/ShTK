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
        public Drawable[] Children;

        public App()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (IResourceHolder i in Children)
            {
                i.Load();
                i.LoadComplete();
            }
        }

        public override void Update()
        {
            base.Update();

            foreach (IUpdatable i in Children)
                i.Update();
        }

        public override void Draw()
        {
            base.Draw();

            foreach (IDrawable i in Children)
                i.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
