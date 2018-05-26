using OpenTK;
using OpenTK.Input;

namespace ShTK.Input
{
    public class MouseListener : IUpdatable
    {
        public Point Position;

        MouseState oldState;
        MouseState newState;

        public bool ButtonDown(MouseButton mb)
        {
            return newState.IsButtonDown(mb) && oldState.IsButtonUp(mb);
        }

        public bool Button(MouseButton mb)
        {
            return newState.IsButtonDown(mb);
        }

        public bool ButtonUp(MouseButton mb)
        {
            return newState.IsButtonUp(mb) && oldState.IsButtonDown(mb);
        }

        public void Update()
        {
            newState = Mouse.GetState();
        }

        public void LateUpdate()
        {
            oldState = newState;
        }
    }
}
