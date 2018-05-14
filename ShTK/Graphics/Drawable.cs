using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Maths;

namespace ShTK.Graphics
{
    public enum Axis
    {
        Width,
        Height
    }

    /// <summary>
    /// Anything that can load and draw is considered a drawable
    /// </summary>
    public abstract class Drawable : IDrawable, IUpdatable, IDisposable
    {
#region fields
        public abstract bool Visible                { get; set; }

        private float alpha = 1;

        public float? ParentAlpha;

        public float Alpha
        {
            get
            {
                if (ParentAlpha == null)
                {
                    return alpha;
                }
                else
                {
                    return (float)ParentAlpha * alpha;
                }
            }
            set
            {
                alpha = value;
            }
        }
        
        public abstract Color4 Colour               { get; set; }
        
        public abstract Vector2 Scale               { get; set; }

        public float ParentRotation;
        public abstract float Rotation              { get; set; }

        public abstract Anchor Anchor               { get; set; }
        public abstract Anchor Origin               { get; set; }

        public float X      { get { return Position.X; } set { Position = new Vector2(value, Y); } }
        public float Y      { get { return Position.Y; } set { Position = new Vector2(Scale.X, X); } }

        public float Width  { get { return Scale.X; } set { Scale = new Vector2(value, Height); } }
        public float Height { get { return Scale.Y; } set { Scale = new Vector2(Scale.X, Width); } }

        /// <summary>
        /// Rectangular bounds of parent object. Set to <see cref="App.Bounds"/> by default
        /// </summary>
        public RectangleF parentBounds = App.Bounds.ToRectangleF();

        /// <summary>
        /// Bounds of drawable, read only
        /// </summary>
        public RectangleF Rectangle => new RectangleF(Position, Scale);

        /// <summary>
        /// Use for high level, general use transforms.
        /// </summary>
        public abstract Vector2 Position { get; set; }

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
                throw new Exception("AbsolutePosition is a readonly property and cannot be set, use Position, X or Y properties instead");
            }
        }

#endregion

#region methods

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
        #endregion

        #region utils
        /// <summary>
        /// Get the percentage of an axis. Returns 0 if an error has occured.
        /// </summary>
        /// <param name="perc"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public float GetProportional(float perc, Axis a)
        {
            switch (a)
            {
                case Axis.Width:
                    return MathsUtils.GetProportional(perc, Width);

                case Axis.Height:
                    return MathsUtils.GetProportional(perc, Height);
            }

            return 0;
        }
        #endregion

        #region static methods
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
            Child.Colour = Parent.Colour;
            Child.ParentRotation = Parent.Rotation;
            Child.ParentAlpha = Parent.Alpha;
            Child.parentBounds = new RectangleF(Parent.AbsolutePosition, Parent.Scale);
        }
#endregion
    }
}