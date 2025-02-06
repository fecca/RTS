using System;
using Inputs;
using UnityEngine;
using VContainer.Unity;
using World.Ground;

namespace Players
{
    public class PlayerController : 
        IPlayerController, 
        IInitializable, 
        IObservable<PlayerModel>,
        IObserver<GroundModel>, 
        IObserver<KeyboardKeyModel>,
        ITickable
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;
        private readonly ProjectileFactory _projectileFactory;
        private DateTime _startTime;

        public event Action<PlayerModel> OnChange = _ => { };

        public PlayerController(IPlayerView view, ProjectileFactory projectileFactory)
        {
            _projectileFactory = projectileFactory;
            _view = view;
            _model = new PlayerModel();
            _model.OnTargetPositionChanged += UpdateTargetPosition;
            _model.OnHealthChanged += UpdateHealth;
            _model.OnDeath += HandleDeath;
        }

        public void Initialize()
        {
            _view.SetController(this);
            _startTime = DateTime.Now;
        }

        private void UpdateTargetPosition(Vector3 position)
        {
            if (_model.IsDead) return;
            
            _view.UpdateTargetPosition(position);
            OnChange.Invoke(_model);
        }

        private void HandleDeath()
        {
            _model.TargetPosition = _view.GetCurrentWorldPosition();
            _view.OnDeath();
            OnChange.Invoke(_model);
        }

        private void UpdateHealth(int newHealth)
        {
            if (_model.IsDead) return;
            
            _view.OnHealthChanged(newHealth);
            OnChange.Invoke(_model);
        }

        public void Notify(GroundModel model)
        {
            if (_model.IsDead) return;
            
            _model.TargetPosition = model.InteractionPosition;
        }

        public void Tick()
        {
            if (_model.IsDead) return;
            
            if (DateTime.Now > _startTime + TimeSpan.FromSeconds(10))
            {
                _model.Health -= 1;
                _startTime = DateTime.Now;
            }
        }

        public void Notify(KeyboardKeyModel keyboardKeyModel)
        {
            if (keyboardKeyModel.KeyCode != KeyCode.Space) return;

            var direction = _model.TargetPosition - _view.GetCurrentWorldPosition();
            var position = _view.GetCurrentWorldPosition() + direction.normalized;
            _projectileFactory.Create(position, direction);
        }
    }
}