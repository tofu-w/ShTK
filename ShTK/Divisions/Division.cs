using System;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Graphics;
using ShTK.Graphics.Drawing;
using ShTK.Utils;

namespace ShTK.Divisions
{
    /// <summary>
    /// Vanilla division, does not possess any specific use seperately
    /// </summary>
    public class Division : Drawable
    {
        Box box;

        public Lazylist<Drawable> Children;

        /// <summary>
        /// Will draw a <see cref="Box"/> in place of the division.
        /// Draws behind all the children
        /// </summary>
        public bool Fill;

        public override bool Visible { get; set; }
        public override float Alpha { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Scale { get; set; }
        public override float Rotation { get; set; }
        public override Anchor Anchor { get; set; }
        public override Anchor Origin { get; set; }
        public override Vector2 Position { get; set; }

        public Division()
        {
            Children = new Lazylist<Drawable>();

            box = new Box()
            {
                Visible = true,
                Colour = Color4.White
            };
        }

        public void Add(IBaseDrawable i)
        {
            Children.Push(i as Drawable);
        }

        public override void LoadComplete()
        {
            Children.SiftQueue();
        }

        public override void Update()
        {
            //Update transformations
            MaintainChildParentRelationship(Children.List, this);

            box.Position = AbsolutePosition;
            box.Scale = Scale;
        }

        public override void Draw()
        {
            //TODO toggle visibillity with fill
            if (Fill)
                box.Draw();

            base.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
