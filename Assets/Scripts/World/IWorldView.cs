namespace World
{
    public interface IWorldView<in T>
    {
        void SetController(T controller);
    }
}