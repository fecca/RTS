﻿using UnityEngine;
using UnityEngine.Events;

namespace Inputs
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent<Vector3> onInteract;

        public void Interact(Vector3 position)
        {
            onInteract.Invoke(position);
        }
    }
}