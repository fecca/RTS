using System;
using UnityEngine;

namespace Players
{
    public class PlayerModel
    {
        private Vector3 _position;

        public Vector3 Position
        {
            set
            {
                if (_position == value) return;
                _position = value;
                OnPositionChanged.Invoke(_position);
            }
        }

        public event Action<Vector3> OnPositionChanged = _ => { };
    }
}