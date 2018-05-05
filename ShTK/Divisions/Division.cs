﻿using System;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Graphics;
using ShTK.Graphics.Drawing;
using ShTK.Utils;

namespace ShTK.Divisions
{
    public class Division : Drawable, IUpdatable, IDisposable
    {
        Box box;

        public Lazylist<Drawable> Children = new Lazylist<Drawable>();

        public override bool Visible { get; set; }
        public override float Alpha { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Position { get; set; }
        public override Vector2 Scale { get; set; }
        public override float Rotation { get; set; }
        public override Anchor Anchor { get; set; }
        public override Anchor Origin { get; set; }

        public RectangleF Bounds => new RectangleF(Position, Scale);

        /// <summary>
        /// Will draw a <see cref="Box"/> in place of the division.
        /// Draws behind all the children
        /// </summary>
        public bool Fill;

        public Division()
        {
            Children.OnSiftItem += SiftedItem;
        }

        public void Add(IBaseDrawable i)
        {
            Children.Push(i as Drawable);
        }

        void SiftedItem(object o)
        {
            Console.WriteLine(o);
        }

        public override void LoadComplete()
        {
            base.LoadComplete();

            Children.SiftQueue();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual void Update()
        {
        }

        public virtual void LateUpdate()
        {
        }
    }
}
