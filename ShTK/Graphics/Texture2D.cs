using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ShTK.Graphics
{
    public class Texture2D : Drawable
    {
        private int id;
        private int width, height;

        public int ID { get { return id; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public override bool Visible { get; set; }
        public override float Alpha { get; set; }
        public override Vector2 Position { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Scale { get; set; }
        public override float Rotation { get; set; }

        public override Anchor Anchor { get; set; }
        public override Anchor Origin { get; set; }

        private Rectangle lockbits;

        public Texture2D(int id, int width, int height)
        {
            this.id = id;
            this.width = width;
            this.height = height;

            Visible = true;
            Alpha = 1.0f;
        }

        //TODO: implement unified content pipeline that doesn't suck
        //also add support for multiple sprites and animation
        public Texture2D(string path)
        {
            Load(path);
        }

        public Texture2D(string path, Rectangle LockbitsRange)
        {
            Bitmap bitmap = new Bitmap(path);
            lockbits = LockbitsRange;
            Load(bitmap, LockbitsRange);
        }

        public void Load(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            Load(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
        }

        public void Load(Bitmap bitmap, Rectangle LockbitsRange)
        {
            int id = GL.GenTexture();

            BitmapData bmpData = bitmap.LockBits(
                LockbitsRange.ToSystemDrawing(),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.BindTexture(TextureTarget.Texture2D, id);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                LockbitsRange.Width,
                LockbitsRange.Height,
                0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                bmpData.Scan0);

            bitmap.UnlockBits(bmpData);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Linear);

            this.id = id;
            this.width = bitmap.Width;
            this.height = bitmap.Height;

            bitmap.Dispose();
        }

        public override void Draw()
        {
            //TODO: Try drawing using the Box method (for unification)

            GL.BindTexture(TextureTarget.Texture2D, ID);
            GL.Begin(PrimitiveType.Triangles);
            GL.Color4(Colour);

            //△FDE
            GL.TexCoord2(0, 0); GL.Vertex2(AbsolutePosition.X, AbsolutePosition.Y);                             //F
            GL.TexCoord2(1, 1); GL.Vertex2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y + Scale.Y);         //D
            GL.TexCoord2(0, 1); GL.Vertex2(AbsolutePosition.X, AbsolutePosition.Y + Scale.Y);                   //E

            //△ABC
            GL.TexCoord2(0, 0); GL.Vertex2(AbsolutePosition.X, AbsolutePosition.Y);                             //A
            GL.TexCoord2(1, 0); GL.Vertex2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y);                   //B
            GL.TexCoord2(1, 1); GL.Vertex2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y + Scale.Y);         //C

            GL.End();
        }

        public override void Dispose()
        {
            base.Dispose();
        
            GC.SuppressFinalize(this);
        }
    }
}
