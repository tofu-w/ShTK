using System;
using ShTK.Divisions;
using ShTK.Graphics;
using ShTK.Content;
using ShTK.Screens;

namespace ShTK
{
    public class App : AppWindow
    {
        protected readonly ScreenOverhead ScreenOverhead = ScreenOverhead.GetInstance();

        Division ActiveScreen => ScreenOverhead.Peek();

        //Layout for the base class. Always drawn behind the active screen
        public Drawable[] Children;

        //Everything that needs to be drawn. Children first, then the active screen
        public Division ToDraw;

        public App()
        {
            ScreenOverhead.app = this;
        }

        void ReloadToDraw()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);;
            LoadAllContent();
        }

        public void LoadAllContent()
        {
            //clear ToDraw and then add items to it
            ToDraw = new Division()
            {
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft
            };

            foreach (IBaseDrawable i in Children)
            {
                ToDraw.Add(i);
            }

            if (ActiveScreen != null)
            {
                ActiveScreen.Load();
                foreach (IBaseDrawable i in ActiveScreen.Children)
                    ToDraw.Add(i);
            }

            //load everything in ToDraw
            foreach (IResourceHolder i in ToDraw.Children)
            {
                i.Load();
                i.LoadComplete();
            }

            ActiveScreen.LoadComplete();
        }

        public override void Update()
        {
            base.Update();

            foreach (IUpdatable i in ToDraw.Children)
            {
                i.Update();
                i.LateUpdate();
            }

            ActiveScreen.Update();
            ActiveScreen.LateUpdate();
        }

        public override void Draw()
        {
            base.Draw();

            foreach (IDrawable i in ToDraw.Children)
            {
                i.Draw();
            }
            ActiveScreen.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
