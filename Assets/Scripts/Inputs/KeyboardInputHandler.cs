using UnityEngine;

namespace Inputs
{
    public class KeyboardInputHandler : IInputHandler
    {
        public void HandleInput()
        {
            if (Camera.main == null) return;
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            var randomPosition = new Vector2(Random.value * 1000f, Random.value * 1000f);
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(randomPosition), out var hit)) return;

            hit.collider.GetComponent<IInteractable>()?.Interact(hit.point);
        }
    }
}