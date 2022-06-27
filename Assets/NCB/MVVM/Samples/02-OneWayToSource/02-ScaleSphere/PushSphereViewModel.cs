using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/PushSphere")]
    public class PushSphereViewModel : ViewModelBase
    {
        private readonly float _baseUnit;

        private float _positionFactor;

        public float PositionFactor
        {
            get => _positionFactor;
            set
            {
                SetProperty(nameof(PositionFactor), ref _positionFactor, value);
                NotifyPropertyChanged(nameof(FinalPosition));
            }
        }

        public Vector3 FinalPosition => new Vector3(0, _baseUnit * PositionFactor, 0);


        public PushSphereViewModel()
        {
            _baseUnit = 5;
        }
    }
}