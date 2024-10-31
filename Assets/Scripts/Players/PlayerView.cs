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

        public void OnPositionChanged(Vector3 position)
        {
            gameObject.transform.position = position + Vector3.up;
        }

        public void OnHealthChanged(int newHealth)
        {
            Debug.Log(newHealth);
        }

        public void OnDeath()
        {
            Destroy(gameObject);
        }
    }
}