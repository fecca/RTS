using VContainer.Unity;

namespace Inputs
{
    public class InputSystem : ITickable
    {
        private readonly IInputHandler _inputHandler;

        protected InputSystem(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Tick()
        {
            _inputHandler.HandleInput();
        }
    }
}