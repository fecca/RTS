using System;
using UnityEngine;

namespace World.Ground
{
    public interface IGroundObserver
    {
        void OnObservedInteractionChange(Vector3 position);
    }
}