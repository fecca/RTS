using System;
using System.Collections.Generic;
using Players;
using UnityEngine;

namespace World.Ground
{
    public abstract class ObservableModel
    {
        private readonly HashSet<Observer> _observers = new();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        protected void Notify(Vector3 position)
        {
            foreach (var observer in _observers) observer.Update(position);
        }
    }

    public class GroundModel : ObservableModel
    {
        private Vector3 _interactionPosition;

        public Vector3 InteractionPosition
        {
            get => _interactionPosition;
            set
            {
                if (_interactionPosition == value) return;
                _interactionPosition = value;
                OnInteraction.Invoke(_interactionPosition);
                Notify(_interactionPosition);
                _interactionPosition = default;
            }
        }

        public event Action<Vector3> OnInteraction = _ => { };
    }

    public abstract class Observer
    {
        public abstract void Update(Vector3 position);
    }

    public class GroundModelObserver : Observer, IDisposable
    {
        private readonly GroundModel _groundModel;
        private readonly PlayerModel _playerModel;

        public GroundModelObserver(GroundModel groundModel, PlayerModel playerModel)
        {
            _groundModel = groundModel;
            _playerModel = playerModel;

            groundModel.Attach(this);
        }

        public void Dispose()
        {
            _groundModel.Detach(this);
        }

        public override void Update(Vector3 position)
        {
            _playerModel.Position = position;
        }
    }
}