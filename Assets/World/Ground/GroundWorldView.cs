using UnityEngine;

namespace World.Ground
{
    public class GroundWorldView : MonoBehaviour, IGroundWorldView
    {
        private IGroundPresenter _presenter;

        public void SetPresenter(IGroundPresenter presenter)
        {
            _presenter = presenter;
        }

        public void OnInteraction(Vector3 clickPosition)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = clickPosition;
        }

        public void Interact(Vector3 position)
        {
            _presenter.Interact(position);
        }
    }
}