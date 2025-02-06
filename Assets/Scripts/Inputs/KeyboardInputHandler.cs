using System;
using UnityEngine;

namespace Inputs
{
    public class KeyboardInputHandler : IInputHandler, IObservable<KeyboardKeyModel>
    {
        private readonly KeyboardKeyModel _keyboardKeyModel = new();

        public KeyboardInputHandler()
        {
            _keyboardKeyModel.OnKeyCodeChange += OnKeyChanged;
        }

        private void OnKeyChanged(KeyCode keyCode)
        {
            OnChange.Invoke(_keyboardKeyModel);
        }

        public void HandleInput()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _keyboardKeyModel.KeyCode = KeyCode.Space;
                _keyboardKeyModel.KeyCode = KeyCode.None;
            }
        }

        public event Action<KeyboardKeyModel> OnChange = _ => { };
    }
}