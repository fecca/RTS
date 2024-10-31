using System;
using UnityEngine;
using VContainer.Unity;
using World.Ground;

namespace Players
{
    public class PlayerController : 
        IPlayerController, 
        IInitializable, 
        IObserver<GroundModel>, 
        IObservable<PlayerModel>,
        ITickable
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;
        private DateTime _startTime;

        public event Action<PlayerModel> OnChange = _ => { };

        public PlayerController(IPlayerView view)
        {
            _view = view;
            _model = new PlayerModel();
            _model.OnPositionChanged += UpdatePosition;
            _model.OnHealthChanged += UpdateHealth;
            _model.OnDeath += HandleDeath;
        }

        public void Initialize()
        {
            _view.SetController(this);
            _startTime = DateTime.Now;
        }

        private void UpdatePosition(Vector3 position)
        {
            if (_model.IsDead) return;
            
            _view.OnPositionChanged(position);
            OnChange.Invoke(_model);
        }

        private void HandleDeath()
        {
            _view.OnDeath();
            OnChange.Invoke(_model);
        }

        private void UpdateHealth(int newHealth)
        {
            if (_model.IsDead) return;
            
            _view.OnHealthChanged(newHealth);
            OnChange.Invoke(_model);
        }

        public void Update(GroundModel model)
        {
            if (_model.IsDead) return;
            
            _model.Position = model.InteractionPosition;
        }

        public void Tick()
        {
            if (_model.IsDead) return;
            
            if (DateTime.Now > _startTime + TimeSpan.FromSeconds(1))
            {
                _model.Health -= 1;
                _startTime = DateTime.Now;
            }
        }
    }
}