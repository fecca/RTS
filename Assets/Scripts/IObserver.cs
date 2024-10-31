public interface IObserver<in T> where T : class
{
    void Update(T model);
}