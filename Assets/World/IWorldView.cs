using UnityEngine;

namespace World
{
    public interface IWorldView<in T>
    {
        void SetPresenter(T presenter);
        void OnInteraction(Vector3 clickPosition);
    }
}