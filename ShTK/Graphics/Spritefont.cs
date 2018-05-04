using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;

namespace ShTK.Graphics
{
    public class Spritefont : IDisposable
    {
        string path;
        Vector2 CellSize;

        public string text;
        public int size = 30;

        public Color4 Colour { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public bool Visible { get; set; }

        Texture2D sheet;
        List <Texture2D> Char;

        Vector2 count;

        public Spritefont(string path, Vector2 cellSize)
        {
            this.path = path;
            this.CellSize = cellSize;

            Visible = true;
            Colour = Color4.White;
        }

        public void Load()
        {
            sheet = new Texture2D(path);
            Char = new List<Texture2D>();

            count = new Vector2(sheet.Width / CellSize.X, sheet.Height / CellSize.Y);
            
            int a = 0;
            foreach (char c in text)
            {
                if (c != ' ')
                {
                    Char.Add(new Texture2D(path, PointFromChar(c))
                    {
                        Scale = Scale,
                        Position = new Vector2(Position.X + (count.X / 2) * a, Position.Y)
                    });
                }

                a++;
            }

            sheet.Dispose();
        }

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

        public void Draw()
        {
            foreach (Texture2D t in Char)
                t.Draw();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Update() { }
    }
}
