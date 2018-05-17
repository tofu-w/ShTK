using OpenTK.Input;

namespace ShTK.Input
{
    public class KeyListener : IUpdatable
    {
        KeyboardState oldState;
        KeyboardState newState;

        /// <summary>
        /// Checks if the key is down, regardless of stroke
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool KeyDown(Key k)
        {
            if (newState.IsKeyDown(k))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the key has been released from a depressed state
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool KeyReleased(Key k)
        {
            if (newState.IsKeyUp(k) && oldState.IsKeyDown(k))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the key is being pressed
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool KeyPressed(Key k)
        {
            if (newState.IsKeyDown(k) && oldState.IsKeyUp(k))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update()
        {
            newState = Keyboard.GetState();
        }

        public void LateUpdate()
        {
            oldState = newState;
        }
    }
}
