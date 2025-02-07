using UnityEngine;
using VContainer.Unity;

namespace World.Houses
{
    public class HouseSpawner : IInitializable
    {
        private readonly HouseFactory _factory;

        public HouseSpawner(HouseFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            SpawnHouseAt(new Vector3(2, 0, 2));
            SpawnHouseAt(new Vector3(2, 0, -2));
            SpawnHouseAt(new Vector3(-2, 0, -2));
            SpawnHouseAt(new Vector3(-2, 0, 2));
        }

        private void SpawnHouseAt(Vector3 position)
        {
            var house = _factory.Create(position);
            var houseController = new HouseController();
            houseController.Initialize(house);
        }
    }
}