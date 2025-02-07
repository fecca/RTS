using UnityEngine;
using World;
using World.Ground;

namespace Inputs
{
    public class MouseInputHandler : IInputHandler
    {
        public void HandleInput()
        {
            if (Camera.main == null) return;
            if (!Input.GetMouseButtonDown(0)) return;
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit)) return;

            hit.collider.GetComponent<IInteractable>()?.Interact(hit.point);
        }
    }
}