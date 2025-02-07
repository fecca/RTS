using System;

namespace World.Houses
{
    public class HouseModel
    {
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnSelected.Invoke(_isSelected);
            }
        }
        
        public event Action<bool> OnSelected = _ => { };
    }
}