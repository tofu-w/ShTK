using System;
using System.Collections.Generic;
using System.Collections;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Graphics;
using ShTK.Graphics.Drawing;
using ShTK.Generic;
using ShTK.Content;
using ShTK.Graphics.OpenGL.Shaders;

namespace ShTK.Divisions
{
    /// <summary>
    /// Vanilla division, handles loops for objects automatically
    /// </summary>
    public class Division : BaseDivision
    {
        public override void Load()
        {
            base.Load();

            foreach (IResourceHolder i in Children)
                i.Load();
        }

        public override void LoadComplete()
        {
            base.LoadComplete();

            foreach (IResourceHolder i in Children)
                i.LoadComplete();
        }

        public override void Update()
        {
            base.Update();

            foreach (IUpdatable i in Children)
                i.Update();
        }

        public override void LateUpdate()
        {
            base.LateUpdate();

            foreach (IUpdatable i in Children)
                i.LateUpdate();
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

            foreach (IDisposable i in Children)
                i.Dispose();
        }
    }

    /// <summary>
    /// All the base logic needed to make a division a division. Does not possess any specific use seperately
    /// </summary>
    public class BaseDivision : Drawable, ICollection <IBaseDrawable> 
    {
        Box box;

        //An easy way to layout and arrange children during initialisation
        public Drawable[] Layout;

        //New items that need to be sifted and loaded etc
        Lazylist<Drawable> Siftables;

        //Final list of drawables to be drawn to the screen
        public List<Drawable> Children;

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

        public override VSFS vsfs { get; }

        public BaseDivision()
        {
            Children = new List<Drawable>();
            Siftables = new Lazylist<Drawable>();
            Siftables.OnSiftItem += OnSiftablesSift;
        }

        public override void Load()
        {
            //Add backing box
            box = new Box()
            {
                Visible = true,
                Colour = Color4.White
            };

            Children.Add(box);

            foreach (var i in Layout)
            {
                Children.Add(i);
            }

            base.Load();
        }

        public override void Update()
        {
            //Update transformations
            MaintainChildParentRelationship(Children, this);

            //Fill
            box.Position = AbsolutePosition;
            box.Scale = Scale;
            box.Colour = Colour;
            box.Alpha = Alpha;
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
                throw new Exception($"Could not parse type {i.GetType()} or its children. Try pushing something of type IBaseDrawable or similar");
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

        //TODO
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
