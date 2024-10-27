using UnityEngine;
using World;

namespace Players
{
    public interface IPlayerView : IWorldView<IPlayerController>
    {
        void OnPositionChanged(Vector3 position);
    }
}