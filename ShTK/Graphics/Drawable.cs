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
        /// <summary>
        /// Responsible for handling not only Draw calls but Update calls as well. 
        /// Disabling Visible will effectively disable the Drawable altogether.
        /// For proper disposal use <see cref="Dispose()"/>
        /// </summary>
        public abstract bool Visible                { get; set; }

        /// <summary>
        /// Drawable's opacity, uses a scale of 0 to 1
        /// </summary>
        public abstract float Alpha                 { get; set; }

        /// <summary>
        /// Tint of Drawable
        /// </summary>
        public abstract Color4 Colour               { get; set; }

        //Relative position
        /// <summary>
        /// Use for high level, general use transforms.
        /// </summary>
        public abstract Vector2 Position            { get; set; }

        public abstract Vector2 Scale               { get; set; }

        public float ParentRotation;
        public abstract float Rotation              { get; set; }


        public abstract Anchor Anchor { get; set; }
        public abstract Anchor Origin { get; set; }

        /// <summary>
        /// Rectangular bounds of parent object
        /// </summary>
        public RectangleF parentBounds = App.Bounds.ToRectangleF();

        public RectangleF Rectangle => new RectangleF(Position, Scale);
        
        //READONLY
        /// <summary>
        /// Should *not* be used for high level code
        /// </summary>
        public Vector2 AbsolutePosition
        {
            get
            {
                return new Vector2
                (
                    Anchors.VectorFromAnchor(Anchor, parentBounds).X - Anchors.VectorFromAnchor(Origin, Rectangle).X + Position.X * 2,
                    Anchors.VectorFromAnchor(Anchor, parentBounds).Y - Anchors.VectorFromAnchor(Origin, Rectangle).Y + Position.Y * 2
                );
            }
            set
            {
                throw new Exception("AbsolutePosition cannot be set, use Position vector2 instead");
            }
        }

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
            Child.parentBounds = new RectangleF(Parent.AbsolutePosition, Parent.Scale);
        }
    }
}