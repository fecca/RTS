using UnityEngine;

namespace World
{
    public interface IWorldView<in T>
    {
        void SetController(T presenter);
        void OnInteraction(Vector3 position);
    }
}