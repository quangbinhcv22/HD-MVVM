using System.ComponentModel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding]
    public class FpsViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        [ShowInInspector] public int Fps { get; set; }

        private void Update()
        {
            Fps = (int) (1 / Time.deltaTime);
            NotifyPropertyChanged(nameof(Fps));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}