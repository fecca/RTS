using UnityEngine;

namespace Players
{
    public class PlayerWorldView : MonoBehaviour, IPlayerWorldView
    {
        private IPlayerWorldPresenter _presenter;

        public void SetPresenter(IPlayerWorldPresenter presenter)
        {
            _presenter = presenter;
        }

        public void OnInteraction(Vector3 clickPosition)
        {
        }

        public void OnPositionChanged(Vector3 position)
        {
            gameObject.transform.position = position;
        }
    }
}