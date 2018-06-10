using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ShTK.Content;

namespace ShTK.Graphics.OpenGL.Shaders
{
    /// <summary>
    /// A single class to hold both the vertex shader and the fragment shader
    /// </summary>
    public class VSFS : IResourceHolder
    {
        public int pgmID;
        public int vsID;
        public int fsID;

        public VertexAttributes vertexAttributes;
        public Shader VertexShader;
        public Shader FragmentShader;

        public int vbo_position;
        public int vbo_color;
        public int vbo_mview;

        public VSFS(int pgmID)
        {
            this.pgmID = pgmID;
        }

        public void Load()
        {
            //TODO move over to ShaderStore or some equivalent
            VertexShader = new Shader()
            {
                Path = @"ShTK_res\Shaders\vs.glsl",
                ShaderType = ShaderType.VertexShader
            };

            FragmentShader = new Shader()
            {
                Path = @"ShTK_res\Shaders\fs.glsl",
                ShaderType = ShaderType.FragmentShader
            };

            vertexAttributes = new VertexAttributes(VertexShader, pgmID);

            VertexShader.Load(pgmID, out vsID);
            FragmentShader.Load(pgmID, out fsID);

            GL.LinkProgram(pgmID);
            Console.WriteLine(pgmID); //TODO move over to debug library

            if (vertexAttributes.Vpos == -1 || vertexAttributes.Vpos == -1 || vertexAttributes.Vpos == -1)
            {
                Console.WriteLine("Error binding attributes");     
            }

            GL.GenBuffers(1, out vbo_position);
            GL.GenBuffers(1, out vbo_color);
            GL.GenBuffers(1, out vbo_mview);
        }

        public void LoadComplete()
        {
        }
    }
}
