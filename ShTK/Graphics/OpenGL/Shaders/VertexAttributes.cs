using OpenTK.Graphics.OpenGL;

namespace ShTK.Graphics.OpenGL.Shaders
{
    public class VertexAttributes
    {
        Shader VS;
        int pgmID;

        public int Vpos
        {
            get
            {
                return GL.GetAttribLocation(pgmID, "vPosition"); 
            }
        }

        public int Vcol
        {
            get
            {
                return GL.GetAttribLocation(pgmID, "vColor"); 
            }
        }

        public int Mview
        {
            get
            {
                return GL.GetUniformLocation(pgmID, "modelview"); 
            }
        }

        public VertexAttributes(Shader vs, int pgmID)
        {
            VS = vs;
            this.pgmID = pgmID;
        }
    }
}
