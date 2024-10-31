using UnityEngine;

namespace Players
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField] private PlayerMovement playerMovement;
        
        private IPlayerController _controller;

        public void SetController(IPlayerController controller)
        {
            _controller = controller;
        }

        public void UpdateTargetPosition(Vector3 position)
        {
            playerMovement.MoveTo(position);
        }

        public void OnHealthChanged(int newHealth)
        {
            Debug.Log(newHealth);
        }

        public void OnDeath()
        {
            Destroy(gameObject);
            Dispose();
        }

        public Vector3 GetCurrentWorldPosition()
            => transform.position;

        public void Dispose()
        {
            _controller.Dispose();
        }
    }
}