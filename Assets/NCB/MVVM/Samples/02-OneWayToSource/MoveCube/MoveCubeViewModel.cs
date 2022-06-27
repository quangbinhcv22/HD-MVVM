using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/MoveCube")]
    public class MoveCubeViewModel : ViewModelMonoBehaviorBase
    {
        private const float Speed = 0.1f;

        [SerializeField] private Vector2 moveIndicator;

        private Vector3 _cubePosition;


        public Vector2 MoveIndicator
        {
            get => moveIndicator;
            set => SetProperty(nameof(MoveIndicator), ref moveIndicator, value.normalized);
        }

        public Vector3 CubePosition
        {
            get => _cubePosition;
            set => SetProperty(nameof(CubePosition), ref _cubePosition, value);
        }

        private void FixedUpdate()
        {
            MoveByDirection();
        }

        private void MoveByDirection()
        {
            CubePosition += new Vector3(moveIndicator.x, default, moveIndicator.y) * Speed;
        }
    }
}