using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Graphics;
using ShTK.Graphics.Drawing;
using ShTK.Utils;
using ShTK.Content;

namespace ShTK.Divisions
{
    public class Division : Drawable, IUpdatable, IDisposable
    {
        Box box;

        Lazylist<IBaseDrawable> Children = new Lazylist<IBaseDrawable>();

        public override bool Visible { get; set; }
        public override float Alpha { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Position { get; set; }
        public override Vector2 Scale { get; set; }
        public override float Rotation { get; set; }

        public Division()
        {
            Children.OnSiftItem += SiftedItem;
        }

        public void Add(Type i)
        {
            if (i == typeof(IDrawable))
            {
                Children.Push((IDrawable)i);
            }
            else if (i == typeof(IBaseDrawable))
            {
                Children.Push((IBaseDrawable)i);
            }
            else
            {
                throw new Exception($"Cannot add type {i} to Division");
            }
        }

        void SiftedItem()
        {

        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void LateUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
