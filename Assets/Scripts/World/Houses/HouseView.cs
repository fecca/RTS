using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace World.Houses
{
    public class HouseView : MonoBehaviour, IHouseView
    {
        [SerializeField]
        private Color selectedColor;
        
        private Color _defaultColor;
        private IHouseController _controller;
        private IEnumerable<Material> _materials;

        private void Awake()
        {
            _materials = GetComponentsInChildren<MeshRenderer>().Select(r => r.material);
            _defaultColor = _materials.First().color;
        }

        public void SetController(IHouseController controller)
        {
            _controller = controller;
        }

        public void SetSelected(bool isSelected)
        {
            Debug.Log(isSelected);
            foreach (var material in _materials)
            {
                material.color = isSelected ? selectedColor : _defaultColor;   
            }
        }

        public void InteractWith()
        {
            _controller.InteractWith();
        }
    }
}