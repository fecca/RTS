using UnityEngine;

namespace World.Ground
{
    public interface IGroundController : IWorldController
    {
        void Interact(Vector3 position);
    }
}