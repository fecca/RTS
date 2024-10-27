using System;
using UnityEngine;

namespace World.Ground
{
    public interface IGroundObservable
    {
        event Action<Vector3> OnObservedInteractionChange;
    }
}