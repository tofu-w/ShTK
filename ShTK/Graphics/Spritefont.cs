using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using ShTK.Maths;
using ShTK.Divisions;

namespace ShTK.Graphics
{
    public class Spritefont : Division
    {
        string path;
        Vector2 CellSize;

        private string text;

        /// <summary>
        /// The text to display
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                reloadText();
            }
        }

        /// <summary>
        /// The amount of pixels between each character, can be left null to default to width
        /// </summary>
        public int? Spacing;

        Texture2D sheet;

        Vector2 count;

        public override bool? Visible       { get; set; }
        public override Color4 Colour       { get; set; }
        public override Vector2 Scale       { get; set; }
        public override float Rotation      { get; set; }
        public override Anchor Anchor       { get; set; }
        public override Anchor Origin       { get; set; }
        public override Vector2 Position    { get; set; }

        public Spritefont(string path, Vector2 cellSize)
        {
            this.path = path;
            this.CellSize = cellSize;

            Visible = true;

            Layout = new Drawable[]
            {

            };
        }

        /// <summary>
        /// Called every time the <see cref="Text"/> value is setted
        /// </summary>
        void reloadText()
        {
            //TODO make sheets the spitefont
            sheet = new Texture2D(path);
            count = new Vector2(sheet.Width / CellSize.X, sheet.Height / CellSize.Y);

            Children.Clear();

            for (int i = 0; i < Text.Length; i++)
            {
                //storing the character for inspection within the scope of this for loop
                Char c = Text.ToCharArray()[i];

                if (c != ' ')   //Checks for spaces
                {
                    Children.Add(new Texture2D(path, PointFromChar(c))
                    {
                        Position = Position,
                        Scale = Scale,
                        Visible = true
                    });
                }
            }
        }

        /// <summary>
        /// Converts a character to a Lockbitsrange rectangle
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        Rectangle PointFromChar(char c)
        {
            int n = c;

            Vector2 p = new Vector2();

            for (int i = 0; i < n; i++)
            {
                if (i % count.X == 0 && i != 0)
                {
                    p.Y++;
                    p.X = 0;
                }

                p.X++;
            }

            return new Rectangle(p.X * CellSize.X, p.Y * CellSize.Y, CellSize.X, CellSize.Y);
        }

        public override void Draw()
        {
            base.Draw();

            if (Visible ?? true)
            {
                //Set the position of characters during runtime
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Position = new Vector2(Position.X + (Spacing ?? Scale.X) * i, Position.Y);
                }
            }
        }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
