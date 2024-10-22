using System;
using UnityEngine;
using VContainer.Unity;

namespace Players
{
    public class PlayerWorldPresenter : IPlayerWorldPresenter, IStartable
    {
        private readonly PlayerModel _model;
        private readonly IPlayerWorldView _view;

        public PlayerWorldPresenter(PlayerModel model, IPlayerWorldView view)
        {
            _view = view;
            _model = model;
        }

        public void Interact(Vector3 position)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _view.SetPresenter(this);
            _model.OnPositionChanged += OnPositionChanged;
        }

        private void OnPositionChanged(Vector3 position)
        {
            _view.OnPositionChanged(position);
        }
    }
}