using System;
using UnityEngine;
using VContainer.Unity;

namespace World.Ground
{
    public class GroundController : IGroundController, IStartable, IGroundObservable
    {
        private readonly GroundModel _model;
        private readonly IGroundView _view;

        public event Action<Vector3> OnObservedInteractionChange = _ => { };

        public GroundController(IGroundView view, IGroundObserverHandler observerHandler)
        {
            _view = view;
            _model = new GroundModel();
            _model.OnInteraction += OnInteraction;
            observerHandler.Observe(this);
        }

        public void Start()
        {
            _view.SetController(this);
        }

        public void Interact(Vector3 position)
        {
            _model.InteractionPosition = position;
        }

        private void OnInteraction(Vector3 clickPosition)
        {
            _view.OnInteraction(clickPosition);
            OnObservedInteractionChange.Invoke(clickPosition);
        }
    }
}