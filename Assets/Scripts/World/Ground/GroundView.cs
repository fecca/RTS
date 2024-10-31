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

        public void ShowDeathEffect(Vector3 position)
        {
            var effect = GameObject.CreatePrimitive(PrimitiveType.Cube);
            effect.transform.position = position;
            effect.transform.localScale = Vector3.one * 0.2f;
        }

        public void ShowInteractionEffect(Vector3 position)
        {
            var effect = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            effect.transform.position = position;
            effect.transform.localScale = Vector3.one * 0.1f;
        }

        public void InteractWith(Vector3 position)
        {
            _controller.InteractWith(position);
        }

        public void Dispose()
        {
            _controller.Dispose();
        }
    }
}