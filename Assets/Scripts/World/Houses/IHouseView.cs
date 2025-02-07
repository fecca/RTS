namespace World.Houses
{
    public interface IHouseView : IWorldView<IHouseController>
    {
        void SetSelected(bool isSelected);
    }
}