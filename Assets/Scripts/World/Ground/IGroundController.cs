using UnityEngine;

namespace World.Ground
{
    public interface IGroundController : IWorldController
    {
        void InteractWith(Vector3 position);
    }
}