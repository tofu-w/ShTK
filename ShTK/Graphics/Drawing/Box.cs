using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using ShTK.Graphics.OpenGL;


namespace ShTK.Graphics.Drawing
{
    public class Box : Shape
    {
        public override List<Vector2> VertexData
        {
            get
            {
                List<Vector2> n = new List<Vector2>();

                n.Add(new Vector2(AbsolutePosition.X, AbsolutePosition.Y));                         //Top left
                n.Add(new Vector2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y));               //Top right    
                n.Add(new Vector2(AbsolutePosition.X, AbsolutePosition.Y + Scale.Y));               //Bottom left  

                //Special thanks to NeRd for spottign a missing comma for this item
                n.Add(new Vector2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y + Scale.Y));     //Bottom right 
                n.Add(new Vector2(AbsolutePosition.X, AbsolutePosition.Y + Scale.Y));               //Bottom left  
                n.Add(new Vector2(AbsolutePosition.X + Scale.X, AbsolutePosition.Y));               //Top right    

                return n;
            }
            set { }
        }

        public Box()
        {
            VertexData = new List<Vector2>();
            AddOrthographicToMviewData(true);

            PrimitiveType = PrimitiveType.Triangles;
        }
    }
}
