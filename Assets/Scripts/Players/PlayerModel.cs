using System;
using UnityEngine;

namespace Players
{
    public class PlayerModel
    {
        private int _health = 10;
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
        
        public bool IsDead => _health <= 0;

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

        public event Action<int> OnHealthChanged = _ => { };
        public event Action OnDeath = () => { };
        public event Action<Vector3> OnTargetPositionChanged = _ => { };
    }
}