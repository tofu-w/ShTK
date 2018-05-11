using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Graphics
{
    /// <summary>
    /// Anything that can load and draw is considered a drawable
    /// </summary>
    public abstract class Drawable : IDrawable, IUpdatable, IDisposable
    {
        public abstract bool Visible                { get; set; }
        public abstract float Alpha                 { get; set; }

        public abstract Color4 Colour               { get; set; }
        public abstract Vector2 Scale               { get; set; }

        public float ParentRotation;
        public abstract float Rotation              { get; set; }

        //Relative position
        /// <summary>
        /// Do NOT use for low level transformations.
        /// General use only
        /// </summary>
        public abstract Vector2 Position { get; set; }

        public abstract Anchor Anchor { get; set; }
        public abstract Anchor Origin { get; set; }

        /// <summary>
        /// Rectangular bounds of parent object
        /// </summary>
        public RectangleF parentBounds = App.Bounds.ToRectangleF();

        public RectangleF Rectangle => new RectangleF(Position, Scale);

        //TODO calculate for anchors
        //READONLY
        /// <summary>
        /// Should *not* be used for high level code
        /// </summary>
        public Vector2 AbsolutePosition => 
            new Vector2
            (
                Anchors.VectorFromAnchor (Anchor, parentBounds).X - Anchors.VectorFromAnchor (Origin, Rectangle).X + parentBounds.X + Position.X, 
                Anchors.VectorFromAnchor (Anchor, parentBounds).Y - Anchors.VectorFromAnchor (Origin, Rectangle).Y + parentBounds.Y + Position.Y
            );

        public Drawable()
        {
            if (Colour == null)
                Colour = Color4.White;            
        }

        public virtual void Load() { }

        public virtual void LoadComplete() { }

        public virtual void Draw() { }

        public virtual void Update() { }

        public virtual void LateUpdate() { }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Transfer transformation properties from one <see cref="IDrawable"/> to a list of <see cref="Drawable"/>
        /// </summary>
        /// <param name="Children"></param>
        /// <param name="Parent"></param>
        public static void MaintainChildParentRelationship(List <Drawable> Children, IDrawable Parent)
        {
            foreach (var c in Children)
            {
                MaintainChildParentRelationship(c, Parent);
            }
        }

        /// <summary>
        /// Transfer transformation properties from one <see cref="IDrawable"/> to another <see cref="Drawable"/>
        /// </summary>
        /// <param name="Children"></param>
        /// <param name="Parent"></param>
        public static void MaintainChildParentRelationship(Drawable Child, IDrawable Parent)
        {
            Child.Visible = Parent.Visible;
            Child.Alpha = Parent.Alpha;
            Child.Colour = Parent.Colour;
            Child.ParentRotation = Parent.Rotation;
            Child.Position = Parent.Position;
        }
    }
}