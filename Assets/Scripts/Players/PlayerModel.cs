using System;
using UnityEngine;

namespace Players
{
    public class PlayerModel
    {
        private int _health = 10;
        private Vector3 _position;

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

        public event Action<int> OnHealthChanged = _ => { };
        public event Action OnDeath = () => { };
        public event Action<Vector3> OnPositionChanged = _ => { };
    }
}