using System;
using MVVM.ModelView;
using Sirenix.OdinInspector;

namespace MVVM.Demo
{
    [Binding] [Serializable]
    public class SliderViewModel : ViewModelBase
    {
        private float _sliderValue;

        [ShowInInspector] public float SliderValue
        {
            get => _sliderValue;
            set => SetProperty( nameof(SliderValue), ref _sliderValue, value);
        }
    }
}