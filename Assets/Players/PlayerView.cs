using UnityEngine;

namespace Players
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        private IPlayerController _controller;

        public void SetController(IPlayerController controller)
        {
            _controller = controller;
        }

        public void OnInteraction(Vector3 position)
        {
        }

        public void OnPositionChanged(Vector3 position)
        {
            gameObject.transform.position = position;
        }
    }
}