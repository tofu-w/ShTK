using System.IO;
using OpenTK.Graphics.OpenGL;

namespace ShTK.Graphics.OpenGL.Shaders
{
    public class Shader
    {
        public string Path;
        public ShaderType ShaderType;

        public void Load(int program, out int address)
        {
            //TODO implement custom content load system
            address = GL.CreateShader(ShaderType);
            using (StreamReader sr = new StreamReader(Path))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }

            GL.CompileShader(address);
            GL.AttachShader(program, address);
        }
    }
}
