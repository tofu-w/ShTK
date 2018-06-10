using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using ShTK.Maths;

namespace ShTK.Graphics.OpenGL
{
    public interface IShape
    {
        List <Vector2> VertexData { get; set; }
        List <Vector3> ColourData { get; set; }
        List <Matrix4> MatrixViewData { get; set; }
    }

    /// <summary>
    /// Class for 2D shapes to inherit from
    /// </summary>
    public class Shape : Drawable, IShape
    {
        //Drawable properties
        public override bool? Visible { get; set; }
        public override Color4 Colour { get; set; }
        public override Vector2 Scale { get; set; }
        public override float Rotation { get; set; }
        public override Anchor Anchor { get; set; }
        public override Anchor Origin { get; set; }
        public override Vector2 Position { get; set; }

        //IShape properties
        public virtual List<Vector2> VertexData { get; set; }
        public virtual List<Vector3> ColourData
        {
            get
            {
                List<Vector3> col = new List<Vector3>();

                foreach (var i in VertexData)
                {
                    col.Add(new Vector3(Colour.R, Colour.G, Colour.B));    //for now, hinder the abillity to add per vertex colouring
                }

                return col;
            }
            set { }
        }
        public List<Matrix4> MatrixViewData { get; set; }

        public PrimitiveType PrimitiveType = PrimitiveType.Triangles;

        public Shape()
        {
        }

        #region shit
        //humwuk
        /*
        void Addsomerandomshittothevertexarrayandstuff()
        {
            VertexData = new List<Vector2>();
            VertexData.Add(new Vector2(0f, 0f));
            VertexData.Add(new Vector2(0f, 500f));
            VertexData.Add(new Vector2(700f, 0f));
            VertexData.Add(new Vector2(900f, 900f));

            ColourData = new List<Vector3>();
            ColourData.Add(new Vector3(1f, 0f, 0f));
            ColourData.Add(new Vector3(0f, 1f, 0f));
            ColourData.Add(new Vector3(0f, 0f, 1f));
            ColourData.Add(new Vector3(1f, 1f, 1f));

            AddIdentityMatrixViewData(true);
        }
        */
        #endregion

        /// <summary>
        /// Adds an orthographic offcentre using <see cref="AppWindow.ScreenBounds"/> to the <see cref="MatrixViewData"/> list
        /// </summary>
        // TODO make a shorter name for this method
        public void AddOrthographicToMviewData(bool initList = false)
        {
            if (initList)
                MatrixViewData = new List<Matrix4>();

            MatrixViewData.Add (Matrix4.CreateOrthographicOffCenter(AppWindow.ScreenBounds.Left, AppWindow.ScreenBounds.Right, AppWindow.ScreenBounds.Bottom, AppWindow.ScreenBounds.Top, -10f, 10f));
        }

        public override void Update()
        {
            base.Update();

            //Convert the vertexdata from vector2 items to vector3 items
            List<Vector3> VertexData3D = new List<Vector3>();
            foreach (Vector2 v in VertexData)
            {
                VertexData3D.Add(new Vector3(v));
            }

            //Vertex data
            GL.BindBuffer(BufferTarget.ArrayBuffer, vsfs.vbo_position);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(VertexData3D.Count * Vector3.SizeInBytes), VertexData3D.ToArray(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(vsfs.vertexAttributes.Vpos, 3, VertexAttribPointerType.Float, false, 0, 0);

            //Colour data
            GL.BindBuffer(BufferTarget.ArrayBuffer, vsfs.vbo_color);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer, (IntPtr)(ColourData.Count * Vector3.SizeInBytes), ColourData.ToArray(), BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(vsfs.vertexAttributes.Vcol, 3, VertexAttribPointerType.Float, true, 0, 0);

            //Matrix view data
            GL.UniformMatrix4(vsfs.vertexAttributes.Mview, false, ref MatrixViewData.ToArray()[0]);
            GL.UseProgram(vsfs.pgmID);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

        }

        public override void Draw()
        {
            base.Draw();

            Draw(AppWindow.ScreenBounds);
        }

        public void Draw(Rectangle Viewport)
        {
            if (Visible ?? true)
            {
                GL.Viewport(Viewport.ToSystemDrawing());
                GL.UniformMatrix4(vsfs.vbo_mview, false, ref MatrixViewData.ToArray()[0]);
                GL.UseProgram(vsfs.pgmID);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

                GL.EnableVertexAttribArray(vsfs.vertexAttributes.Vpos);
                GL.EnableVertexAttribArray(vsfs.vertexAttributes.Vcol);

                GL.DrawArrays(PrimitiveType, 0, VertexData.Count);

                GL.DisableVertexAttribArray(vsfs.vertexAttributes.Vpos);
                GL.DisableVertexAttribArray(vsfs.vertexAttributes.Vcol);

                GL.Flush();
            }
        }
    }
}
