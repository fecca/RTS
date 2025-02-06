using System;
using UnityEngine;

namespace Inputs
{
    public class KeyboardKeyModel
    {
        private KeyCode _keyCode;
        public KeyCode KeyCode
        {
            get => _keyCode;
            set
            {
                if (_keyCode == value) return;
                _keyCode = value;
                OnKeyCodeChange.Invoke(_keyCode);
            }
        }

        public event Action<KeyCode> OnKeyCodeChange = _ => { };
    }
}