using System;
using System.Collections.Generic;
using System.Collections;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Graphics;
using ShTK.Graphics.Drawing;
using ShTK.Generic;
using ShTK.Content;

namespace ShTK.Divisions
{
    /// <summary>
    /// Vanilla division, does not possess any specific use seperately
    /// </summary>
    public class Division : Drawable, ICollection <IBaseDrawable> 
    {
        Box box;

        public Drawable[] Layout;
        Lazylist<Drawable> Siftables;
        public List<Drawable> Children = new List<Drawable>();

        /// <summary>
        /// Will draw a <see cref="Box"/> in place of the division.
        /// Draws behind all the children
        /// </summary>
        public bool Fill;

        public override bool? Visible { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Scale { get; set; } = AppWindow.ScreenBounds.GetScale();
        public override float Rotation { get; set; }
        public override Anchor Anchor { get; set; }
        public override Anchor Origin { get; set; }
        public override Vector2 Position { get; set; }

        public int Count => Layout.Length;

        public bool IsReadOnly => Layout.IsReadOnly;

        public Division()
        {
            Siftables = new Lazylist<Drawable>();
            Siftables.OnSiftItem += OnSiftablesSift;

            box = new Box()
            {
                Visible = true,
                Colour = Color4.White
            };
        }

        public override void Load()
        {
            base.Load();

            foreach (IResourceHolder i in Layout)
            {
                i.Load();
                i.LoadComplete();
            }
        }

        public override void LoadComplete()
        {
            foreach (var i in Layout)
            {
                Children.Add(i);
            }
        }

        public override void Update()
        {
            //Update transformations
            MaintainChildParentRelationship(Layout, this);

            //Fill
            box.Position = AbsolutePosition;
            box.Scale = Scale;
            box.Colour = Colour;
            box.alpha = Alpha;
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

        private void OnSiftablesSift(object o)
        {
            var obj = o as Drawable;
            obj.Load();
            obj.LoadComplete();
            Children.Add(obj);
        }

        public virtual void Add(IBaseDrawable i)
        {
            try
            {
                Siftables.Push(i as Drawable);
                Siftables.SiftQueue();
            }
            catch
            {
                throw new Exception($"Could not parse type {i.GetType()}. Try pushing something of type IBaseDrawable or similar");
            }
        }

        public void Clear()
        {
            foreach (IDisposable i in Layout)
            {
                i.Dispose();
            }

            Array.Clear(Layout, 0, Count);
        }

        public bool Contains(IBaseDrawable item)
        {
            foreach (IBaseDrawable i in Layout)
            {
                return i == item;
            }

            return false;
        }

        public void CopyTo(IBaseDrawable[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IBaseDrawable item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IBaseDrawable> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
