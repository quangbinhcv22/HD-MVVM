using System.ComponentModel;
using MVVM.ModelView;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM.Demo
{
    [Binding]
    public class CubeViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        private Vector3 _scale;
        private Quaternion _rotation;
        private Color _color;

        
        [ShowInInspector]
        public Vector3 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                NotifyPropertyChanged(nameof(Scale));
            }
        }

        [ShowInInspector]
        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                NotifyPropertyChanged(nameof(Rotation));
            }
        }
        
        [ShowInInspector]
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                NotifyPropertyChanged(nameof(Color));
            }
        }


        private void Update()
        {
            Scale = GetScaleAtTime(Time.time);
            Color = GetColorAtTime(Time.time);
            Rotation = GetRotationAtTime(Time.time);
        }


        private Vector3 GetScaleAtTime(float time)
        {
            return Vector3.Lerp(Vector3.one * 0.9f, Vector3.one * 1.8f, Mathf.PingPong(time, 1));
        }

        private Color GetColorAtTime(float time)
        {
            return Color.Lerp(Color.magenta, Color.yellow, Mathf.PingPong(time, 1));
        }

        private Quaternion GetRotationAtTime(float time)
        {
            return Quaternion.Euler(Vector3.Lerp(Vector3.zero, Vector3.one * 360, Mathf.PingPong(time, 1)));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}