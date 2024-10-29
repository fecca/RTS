using UnityEngine;

namespace Players
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        public void SetController(IPlayerController controller)
        {
        }

        public void OnInteraction(Vector3 position)
        {
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