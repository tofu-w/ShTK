using OpenTK;

namespace ShTK.Maths
{
    interface IRectangle
    {
        System.Drawing.Rectangle ToSystemDrawing();
        Vector2 GetPosition();
        Vector2 GetScale();
    }
}
