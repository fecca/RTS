using Inputs;
using Players;
using UnityEngine;
using World.Ground;
using Random = UnityEngine.Random;

namespace DebugOptions
{
    public class DebugInputHandler : IInputHandler
    {
        private readonly GroundModel _groundModel;
        private readonly PlayerModel _playerModel;

        public DebugInputHandler(GroundModel groundModel, PlayerModel playerModel)
        {
            _playerModel = playerModel;
            _groundModel = groundModel;
        }

        public void HandleInput()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;

            _groundModel.InteractionPosition = new Vector3(Random.value * 10 - 5, 1, Random.value * 10 - 5);
            _playerModel.Position = new Vector3(Random.value * 10 - 5, 1, Random.value * 10 - 5);
        }
    }
}