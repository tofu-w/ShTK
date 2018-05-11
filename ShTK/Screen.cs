using System;
using OpenTK;
using ShTK.Divisions;
using ShTK.Graphics;

namespace ShTK
{
    public class Screen : Division
    {
        private bool Loaded;

        public Screen()
        {
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            Position = Vector2.Zero;
            Scale = new Vector2(App.Bounds.Width, App.Bounds.Height);
            Children.OnSiftItem += OnSift;
        }

        //Load all children when they get added as opposed to just on initialisation
        private void OnSift(object o)
        {
            var BaseDrawable = (Drawable)o;
            BaseDrawable.Load();

            //If all the assets have already run their LoadComplete methods,
            //load the child's LoadComplete method directly after sifting
            if (Loaded)
                BaseDrawable.LoadComplete();
        }

        public override void LoadComplete()
        {
            foreach (var c in Children.List)
                c.LoadComplete();

            Loaded = true;

            Children.SiftQueue();

            base.LoadComplete();
        }

        public override void Update()
        {
            base.Update();

            foreach (var c in Children.List)
                c.Update();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();

            foreach (var c in Children.List)
                c.LateUpdate();
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
