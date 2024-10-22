using UnityEngine;
using VContainer.Unity;

namespace World.Ground
{
    public class GroundPresenter : IGroundPresenter, IStartable
    {
        private readonly GroundModel _model;
        private readonly IGroundWorldView _view;

        public GroundPresenter(GroundModel model, IGroundWorldView view)
        {
            _view = view;
            _model = model;
        }

        public void Interact(Vector3 position)
        {
            _model.InteractionPosition = position;
        }

        public void Start()
        {
            _view.SetPresenter(this);
            _model.OnInteraction += OnInteraction;
        }

        private void OnInteraction(Vector3 clickPosition)
        {
            _view.OnInteraction(clickPosition);
        }
    }
}