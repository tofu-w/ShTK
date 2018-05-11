using System;
using System.Drawing;
using System.Reflection;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ShTK
{
    public class App : GameWindow
    {
        public Color4 backgroundColour = Color4.CornflowerBlue; //new Color4 (137, 137, 137, 0);

        public Matrix4 projMatrix;

        public static Rectangle Bounds;

        public App() : base(1366, 768, GraphicsMode.Default, string.Format("Running {0} - Powered by ShTK", Assembly.GetCallingAssembly().GetName().Name))
        {
            Bounds = new Rectangle(ClientRectangle);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.ClearColor(backgroundColour);

            GL.Enable(EnableCap.Texture2D);

            BeginLoad();
        }

        public virtual void BeginLoad()
        {

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Bounds = new Rectangle (ClientRectangle);

            GL.Viewport(0, 0, Width, Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            projMatrix = Matrix4.CreateOrthographicOffCenter(ClientRectangle.Left, ClientRectangle.Right, ClientRectangle.Bottom, ClientRectangle.Top, -1.0f, 1.0f);
            GL.LoadMatrix(ref projMatrix);

            Draw();

            SwapBuffers();
        }

        public virtual void Draw()
        {

        }
    }
}
