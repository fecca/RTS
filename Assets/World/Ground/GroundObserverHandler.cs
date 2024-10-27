using System.Collections.Generic;

namespace World.Ground
{
    public class GroundObserverHandler : IGroundObserverHandler 
    {
        private readonly IEnumerable<IGroundObserver> _observers;

        public GroundObserverHandler(IEnumerable<IGroundObserver> observers)
        {
            _observers = observers;
        }

        public void Observe(IGroundObservable observable)
        {
            observable.OnObservedInteractionChange += position =>
            {
                foreach (var observer in _observers)
                {
                    observer.OnObservedInteractionChange(position); 
                }
            };
        }
    }
}