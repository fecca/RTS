using UnityEngine;

namespace World.Players
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
            Debug.Log($"Health: {newHealth}");
        }

        public void OnDeath()
        {
            Destroy(gameObject);
        }

        public Vector3 GetCurrentWorldPosition()
            => transform.position;
    }
}