using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ProjectileFactory
{
    private readonly IObjectResolver _resolver;
    private readonly ProjectileView _prefab;

    public ProjectileFactory(IObjectResolver resolver, ProjectileView prefab)
    {
        _prefab = prefab;
        _resolver = resolver;
    }

    public void Create(Vector3 position, Vector3 direction)
    {
        var instance = _resolver.Instantiate(_prefab);
        instance.Initialize(position, direction);
    }
}