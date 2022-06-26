using System;
using NCB.MVVM;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor.TypeSearch;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding]
    public class MoveCubeViewModel : ViewModelMonoBehaviorBase
    {
        private const float Speed = 0.1f;

        [SerializeField] private Vector2 _moveIndicator;
        [SerializeField] private Vector2 _rotationIndicator;

        private Vector3 _cubePosition;
        private Quaternion _cubeRotation;


        public Vector2 MoveIndicator
        {
            get => _moveIndicator;
            set => SetProperty(nameof(MoveIndicator), ref _moveIndicator, value.normalized);
        }

        public Vector2 RotationIndicator
        {
            get => _rotationIndicator;
            set
            {
                SetProperty(nameof(RotationIndicator), ref _rotationIndicator, value);

                if (value == Vector2.zero) return;
                CubeRotation = Quaternion.LookRotation(new Vector3(value.x, default, value.y), Vector3.up);
            }
        }

        public Vector3 CubePosition
        {
            get => _cubePosition;
            set => SetProperty(nameof(CubePosition), ref _cubePosition, value);
        }

        public Quaternion CubeRotation
        {
            get => _cubeRotation;
            set => SetProperty(nameof(CubeRotation), ref _cubeRotation, value);
        }


        private void FixedUpdate()
        {
            MoveByDirection();
        }

        private void MoveByDirection()
        {
            CubePosition += new Vector3(_moveIndicator.x, default, _moveIndicator.y) * Speed;
        }
    }
}