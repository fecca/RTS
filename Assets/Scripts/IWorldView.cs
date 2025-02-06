public interface IWorldView<in T>
{
    void SetController(T presenter);
}