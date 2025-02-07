using System;
using UnityEngine;

namespace World.Houses
{
    public class HouseView : MonoBehaviour, IHouseView
    {
        [SerializeField]
        private Color selectedColor;
        
        private Color _defaultColor;
        private IHouseController _controller;
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
        }

        public void SetController(IHouseController controller)
        {
            _controller = controller;
        }

        public void SetSelected(bool isSelected)
        {
            Debug.Log(isSelected);
            _material.color = isSelected ? selectedColor : _defaultColor;
        }

        public void InteractWith()
        {
            _controller.InteractWith();
        }
    }
}