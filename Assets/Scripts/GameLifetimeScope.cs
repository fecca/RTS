using System;
using Inputs;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using World.Ground;
using World.Houses;
using World.Players;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GroundView ground;
    [SerializeField]
    private PlayerView player;
    [SerializeField]
    private ProjectileView projectile;
    [SerializeField]
    private HouseView house;

    protected override void Configure(IContainerBuilder builder)
    {
        // Separate into installers
        BuildInput(builder);
        BuildGround(builder);
        BuildPlayer(builder);
        BuildHouses(builder);
    }

    private static void BuildInput(IContainerBuilder builder)
    {
        builder.Register<InputSystem>(Lifetime.Singleton).As<ITickable>();
        builder.Register<MouseInputHandler>(Lifetime.Singleton).As<IInputHandler>();
        // builder.Register<DebugInputHandler>(Lifetime.Singleton).As<IInputHandler>();
        builder.Register<KeyboardInputHandler>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.Register<ObserverHandler<KeyboardKeyModel>>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private void BuildGround(IContainerBuilder builder)
    {
        builder.Register<GroundController>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.RegisterComponentInNewPrefab(ground, Lifetime.Scoped).As<IGroundView>();
        builder.Register<ObserverHandler<GroundModel>>(Lifetime.Scoped).AsImplementedInterfaces();
    }

    private void BuildPlayer(IContainerBuilder builder)
    {
        builder.Register<PlayerController>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.RegisterComponentInNewPrefab(player, Lifetime.Scoped).As<IPlayerView>();
        builder.Register<ObserverHandler<PlayerModel>>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.Register<ProjectileFactory>(Lifetime.Scoped).WithParameter(typeof(ProjectileView), projectile);
    }

    private void BuildHouses(IContainerBuilder builder)
    {
        builder.Register<HouseSpawner>(Lifetime.Scoped).AsImplementedInterfaces();
        builder.Register<HouseFactory>(Lifetime.Scoped).WithParameter(typeof(HouseView), house);
        builder.Register<HouseController>(Lifetime.Scoped).AsImplementedInterfaces();
        // builder.Register<ObserverHandler<HouseModel>>(Lifetime.Scoped).AsImplementedInterfaces();
    }
}