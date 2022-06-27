using System;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/RotateCube")]
    [Serializable]
    public class RotateCubeViewModel : ViewModelBase
    {
        [SerializeField] private Vector2 rotationIndicator;

        private Quaternion _cubeRotation;

        public Vector2 RotationIndicator
        {
            get => rotationIndicator;
            set
            {
                SetProperty(nameof(RotationIndicator), ref rotationIndicator, value);

                if (value == Vector2.zero) return;
                CubeRotation = Quaternion.LookRotation(new Vector3(value.x, default, value.y), Vector3.up);
            }
        }

        public Quaternion CubeRotation
        {
            get => _cubeRotation;
            set => SetProperty(nameof(CubeRotation), ref _cubeRotation, value);
        }
    }
}