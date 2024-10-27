using System;
using UnityEngine;

namespace World.Ground
{
    public class GroundModel
    {
        private Vector3 _interactionPosition;

        public Vector3 InteractionPosition
        {
            get => _interactionPosition;
            set
            {
                if (_interactionPosition == value) return;
                _interactionPosition = value;
                OnInteraction.Invoke(_interactionPosition);
                _interactionPosition = default;
            }
        }

        public event Action<Vector3> OnInteraction = _ => { };
    }
}