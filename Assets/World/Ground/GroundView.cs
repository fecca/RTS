using UnityEngine;

namespace World.Ground
{
    public class GroundView : MonoBehaviour, IGroundView
    {
        private IGroundController _controller;

        public void SetController(IGroundController controller)
        {
            _controller = controller;
        }

        public void OnInteraction(Vector3 position)
        {
        }

        public void Interact(Vector3 position)
        {
            _controller.Interact(position);
        }
    }
}