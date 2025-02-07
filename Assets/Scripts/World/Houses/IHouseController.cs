namespace World.Houses
{
    public interface IHouseController
    {
        void Initialize(IHouseView houseView);
        void InteractWith();
    }
}