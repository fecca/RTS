using UnityEngine;

namespace World.Ground
{
    public interface IGroundView : IWorldView<IGroundController>
    {
        void ShowDeathEffect(Vector3 position);
        void ShowInteractionEffect(Vector3 position);
    }
}