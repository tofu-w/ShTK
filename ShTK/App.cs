using System;
using System.Reflection;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using ShTK.Input;

namespace ShTK
{
    public class App : GameWindow
    {
        public Color4 backgroundColour = Color4.CornflowerBlue; //new Color4 (137, 137, 137, 0);

        public Matrix4 projMatrix;

        public static Rectangle ScreenBounds;

        public static KeyListener KeyListener = new KeyListener();
        public static MouseListener MouseListener = new MouseListener();

        public App() : base(1366, 768, GraphicsMode.Default, string.Format("Running {0} - Powered by ShTK", Assembly.GetCallingAssembly().GetName().Name))
        {
            ScreenBounds = new Rectangle(ClientRectangle);
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
            
            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.5f);
            
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

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyListener.Update();
            MouseListener.Update();
            MouseListener.Position = new Point (PointToClient(new System.Drawing.Point(Mouse.GetCursorState().X, Mouse.GetCursorState().Y)));

            Update();

            KeyListener.LateUpdate();
            MouseListener.LateUpdate();
        }

        public virtual void Update()
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            ScreenBounds = new Rectangle (ClientRectangle);

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
