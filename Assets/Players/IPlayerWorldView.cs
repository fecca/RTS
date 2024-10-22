using UnityEngine;
using World;

namespace Players
{
    public interface IPlayerWorldView : IWorldView<IPlayerWorldPresenter>
    {
        void OnPositionChanged(Vector3 position);
    }
}