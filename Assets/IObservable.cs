using System;

public interface IObservable<out T> where T : class
{
    event Action<T> OnChange;
}