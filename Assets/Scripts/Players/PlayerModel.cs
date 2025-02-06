using System;
using UnityEngine;

namespace Players
{
    public class PlayerModel
    {
        private int _health = 10;
        private Vector3 _position;
        private Vector3 _targetPosition;

        public int Health
        {
            get => _health;
            set
            {
                if (_health == value) return;
                _health = value;
                OnHealthChanged.Invoke(_health);
                if (_health <= 0) OnDeath.Invoke();
            }
        }

        public Vector3 Position
        {
            get => _position;
            set
            {
                if (_position == value) return;
                _position = value;
                OnPositionChanged.Invoke(_position);
            }
        }

        public Vector3 TargetPosition
        {
            get => _targetPosition;
            set
            {
                if (_targetPosition == value) return;
                _targetPosition = value;
                OnTargetPositionChanged.Invoke(_targetPosition);
            }
        }
        
        public bool IsDead => _health <= 0;

        public event Action<int> OnHealthChanged = _ => { };
        public event Action OnDeath = () => { };
        public event Action<Vector3> OnPositionChanged = _ => { };
        public event Action<Vector3> OnTargetPositionChanged = _ => { };
    }
}