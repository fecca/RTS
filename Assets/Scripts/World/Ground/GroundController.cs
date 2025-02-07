using System;
using UnityEngine;
using VContainer.Unity;
using World.Players;

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
            _model.OnInteractionPositionChange += UpdateInteractionPosition;
        }

        public void Initialize()
        {
            _view.SetController(this);
        }

        public void InteractWith(Vector3 position)
        {
            _model.InteractionPosition = position;
        }

        private void UpdateInteractionPosition(Vector3 position)
        {
            _view.ShowInteractionEffect(position);
            OnChange.Invoke(_model);
        }

        public void Notify(PlayerModel model)
        {
            if (!model.IsDead) return;

            _view.ShowDeathEffect(model.TargetPosition);
        }
    }
}