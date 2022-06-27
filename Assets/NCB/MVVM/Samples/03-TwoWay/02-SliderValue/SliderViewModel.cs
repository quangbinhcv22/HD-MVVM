using System;
using Sirenix.OdinInspector;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/Slider")]
    [Serializable]
    public class SliderViewModel : ViewModelBase
    {
        private float _sliderValue;

        [ShowInInspector]
        public float SliderValue
        {
            get => _sliderValue;
            set => SetProperty(nameof(SliderValue), ref _sliderValue, value);
        }
    }
}