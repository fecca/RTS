using System.Collections.Generic;
using VContainer.Unity;

namespace Inputs
{
    public class InputSystem : ITickable
    {
        private readonly IEnumerable<IInputHandler> _inputHandlers;

        protected InputSystem(IEnumerable<IInputHandler> inputHandlers)
        {
            _inputHandlers = inputHandlers;
        }

        public void Tick()
        {
            foreach (var inputHandler in _inputHandlers)
            {
                inputHandler.HandleInput();   
            }
        }
    }
}