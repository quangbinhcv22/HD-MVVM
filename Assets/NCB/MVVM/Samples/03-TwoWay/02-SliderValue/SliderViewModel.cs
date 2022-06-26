using System;
using NCB.MVVM;
using Sirenix.OdinInspector;

namespace NCB.MVVM.Demo
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