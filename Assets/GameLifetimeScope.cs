using Inputs;
using Players;
using UnityEngine;
using VContainer;
using VContainer.VContainer.Runtime;
using VContainer.VContainer.Runtime.Annotations;
using VContainer.VContainer.Runtime.Unity;
using World.Ground;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GroundView groundView;
    [SerializeField]
    private PlayerView playerView;

    protected override void Configure(IContainerBuilder builder)
    {
        BuildInput(builder);
        BuildGround(builder);
        BuildPlayer(builder);
    }

    private static void BuildInput(IContainerBuilder builder)
    {
        builder.Register<InputSystem>(Lifetime.Singleton).As<ITickable>();
        builder.Register<MouseInputHandler>(Lifetime.Singleton).As<IInputHandler>();
        // builder.Register<DebugInputHandler>(Lifetime.Singleton).As<IInputHandler>();
        // builder.Register<KeyboardInputHandler>(Lifetime.Singleton).As<IInputHandler>();
    }

    private void BuildGround(IContainerBuilder builder)
    {
        builder.Register<GroundController>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterComponentInNewPrefab(groundView, Lifetime.Singleton).As<IGroundView>();
        builder.Register<ObserverHandler<GroundModel>>(Lifetime.Singleton).AsImplementedInterfaces();
    }

    private void BuildPlayer(IContainerBuilder builder)
    {
        builder.Register<PlayerController>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterComponentInNewPrefab(playerView, Lifetime.Singleton).As<IPlayerView>();
        builder.Register<ObserverHandler<PlayerModel>>(Lifetime.Singleton).AsImplementedInterfaces();
    }
}