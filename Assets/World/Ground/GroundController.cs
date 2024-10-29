using System;
using Players;
using UnityEngine;
using VContainer.VContainer.Runtime.Annotations;

namespace World.Ground
{
    public class GroundController : 
        IGroundController, 
        IInitializable, 
        IObservable<GroundModel>,
        IObserver<PlayerModel>
    {
        private readonly GroundModel _model;
        private readonly IGroundView _view;

        public event Action<GroundModel> OnChange = _ => { };

        public GroundController(IGroundView view)
        {
            _view = view;
            _model = new GroundModel();
            _model.OnInteractionPositionChange += OnInteractionPositionChange;
        }

        public void Initialize()
        {
            _view.SetController(this);
        }

        public void Interact(Vector3 position)
        {
            _model.InteractionPosition = position;
        }

        private void OnInteractionPositionChange(Vector3 position)
        {
            _view.ShowInteractionEffect(position);
            OnChange.Invoke(_model);
        }

        public void Update(PlayerModel model)
        {
            if (!model.IsDead) return;

            _view.ShowDeathEffect(model.Position);
        }
    }
}