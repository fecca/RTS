using UnityEngine;

namespace Players
{
    public interface IPlayerView : IWorldView<IPlayerController>
    {
        void UpdateTargetPosition(Vector3 position);
        void OnHealthChanged(int newHealth);
        void OnDeath();
        Vector3 GetCurrentWorldPosition();
    }
}