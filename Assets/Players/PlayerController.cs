using System;
using UnityEngine;
using VContainer.Unity;
using World.Ground;

namespace Players
{
    public class PlayerController : IPlayerController, IStartable, IGroundObserver
    {
        private readonly PlayerModel _model;
        private readonly IPlayerView _view;

        public PlayerController(IPlayerView view)
        {
            _view = view;
            _model = new PlayerModel();
            _model.OnPositionChanged += OnPositionChanged;
        }

        public void Start()
        {
            _view.SetController(this);
        }

        private void OnPositionChanged(Vector3 position)
        {
            _view.OnPositionChanged(position);
        }

        public void OnObservedInteractionChange(Vector3 position)
        {
            _model.Position = position;
        }
    }
}