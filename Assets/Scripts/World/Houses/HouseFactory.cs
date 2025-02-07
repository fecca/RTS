using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace World.Houses
{
    public class HouseFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly HouseView _prefab;

        public HouseFactory(IObjectResolver resolver, HouseView prefab)
        {
            _prefab = prefab;
            _resolver = resolver;
        }
        
        public IHouseView Create(Vector3 position)
        {
            var instance = _resolver.Instantiate(_prefab);
            instance.transform.position = position;
            return instance;
        }
    }
}