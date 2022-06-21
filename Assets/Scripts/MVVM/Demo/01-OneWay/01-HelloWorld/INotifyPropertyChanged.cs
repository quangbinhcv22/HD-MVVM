using System.ComponentModel;

namespace MVVM.Demo
{
    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
        void NotifyPropertyChanged(string propertyName);
    }
}