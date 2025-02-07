using System;

namespace World.Houses
{
    public class HouseController : IHouseController, IObservable<HouseModel>
    {
        private HouseModel _model;
        private IHouseView _view;

        public void Initialize(IHouseView view)
        {
            _view = view;
            _model = new HouseModel();
            _model.OnSelected += HandleSelectionChanged;
            _view.SetController(this);
        }
        
        public void InteractWith()
        {
            _model.IsSelected = !_model.IsSelected;
            OnChange.Invoke(_model);
        }

        private void HandleSelectionChanged(bool isSelected)
        {
            _view.SetSelected(isSelected);
        }

        public event Action<HouseModel> OnChange = _ => { };
    }
}