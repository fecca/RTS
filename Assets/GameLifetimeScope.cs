using Inputs;
using Players;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using World.Ground;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GroundWorldView groundWorldView;

    [SerializeField] private PlayerWorldView playerWorldView;

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
        builder.Register<GroundModel>(Lifetime.Singleton);
        builder.RegisterEntryPoint<GroundPresenter>().As<IGroundPresenter>();
        builder.RegisterComponent(groundWorldView).As<IGroundWorldView>();
    }

    private void BuildPlayer(IContainerBuilder builder)
    {
        builder.Register<PlayerModel>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerWorldPresenter>().As<IPlayerWorldPresenter>();
        builder.RegisterComponentInNewPrefab(playerWorldView, Lifetime.Scoped).As<IPlayerWorldView>();
    }
}