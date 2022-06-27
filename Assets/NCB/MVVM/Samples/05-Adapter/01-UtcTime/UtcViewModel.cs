using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NCB.MVVM.Demo
{
    [Binding("Demo/Utc")]
    public class UtcViewModel : INotifyPropertyChanged
    {
        public DateTime UtcTime => DateTime.UtcNow;


        public UtcViewModel()
        {
            StartCycle();
        }

        private async void StartCycle()
        {
            var oneSecond = TimeSpan.FromSeconds(1);

            while (true)
            {
                await Task.Delay(oneSecond);
                NotifyPropertyChanged(nameof(UtcTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}