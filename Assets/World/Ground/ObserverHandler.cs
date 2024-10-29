using System.Collections.Generic;
using VContainer.VContainer.Runtime.Annotations;

namespace World.Ground
{
    public class ObserverHandler<T> : IObserverHandler, IInitializable where T : class
    {
        private readonly IObservable<T> _observable;
        private readonly IEnumerable<IObserver<T>> _observers;

        public ObserverHandler(IObservable<T> observable, IEnumerable<IObserver<T>> observers)
        {
            _observers = observers;
            _observable = observable;
        }
        
        public void Initialize()
        {
            _observable.OnChange += model =>
            {
                foreach (var observer in _observers)
                {
                    observer.Update(model); 
                }
            };
        }
    }
}