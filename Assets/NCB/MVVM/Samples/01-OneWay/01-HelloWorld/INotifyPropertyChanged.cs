using System.ComponentModel;

namespace NCB.MVVM
{
    public interface INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
    }
}