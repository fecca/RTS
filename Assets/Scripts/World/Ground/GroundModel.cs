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
                OnInteractionPositionChange.Invoke(_interactionPosition);
            }
        }

        public event Action<Vector3> OnInteractionPositionChange = _ => { };
    }
}