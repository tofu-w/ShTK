using OpenTK;
using OpenTK.Input;

namespace ShTK.Input
{
    public enum Stroke
    {
        Down,
        Pressed,
        Up
    }

    public class MouseListener : IUpdatable
    {
        public Point Position;

        MouseState oldState;
        MouseState newState;

        public bool Button(Stroke s, MouseButton mb)
        {
            bool cond;
            
            switch (s)
            {
                case Stroke.Pressed:
                    cond = newState.IsButtonDown(mb) && oldState.IsButtonUp(mb);
                    break;

                case Stroke.Up:
                    cond = newState.IsButtonUp(mb) && oldState.IsButtonDown(mb);
                    break;

                default:
                    cond = newState.IsButtonDown(mb);
                    break;
            }

            return cond;
        }

        public void Update()
        {

        }

        public void LateUpdate()
        {

        }
    }
}
