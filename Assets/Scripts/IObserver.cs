public interface IObserver<in T> where T : class
{
    void Notify(T model);
}