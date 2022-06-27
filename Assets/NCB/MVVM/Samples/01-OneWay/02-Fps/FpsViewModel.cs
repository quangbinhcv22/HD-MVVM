using System.ComponentModel;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/Fps")]
    public class FpsViewModel : MonoBehaviour, INotifyPropertyChanged
    {
        public int Fps => (int) (1 / Time.deltaTime);

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void Update()
        {
            NotifyPropertyChanged(nameof(Fps));
        }
    }
}