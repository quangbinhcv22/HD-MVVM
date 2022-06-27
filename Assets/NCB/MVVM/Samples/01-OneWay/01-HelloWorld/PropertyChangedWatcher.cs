using System;
using System.ComponentModel;

namespace NCB.MVVM.Demo
{
    public class PropertyChangedWatcher : IEventWatcher
    {
        private readonly INotifyPropertyChanged _notifier;
        private readonly string _propertyName;
        private readonly Action _callback;

        public PropertyChangedWatcher(INotifyPropertyChanged notifier, string propertyName, Action callback)
        {
            _notifier = notifier;
            _propertyName = propertyName;
            _callback = callback;
        }

        public void Watch()
        {
            _notifier.PropertyChanged += OnPropertyChanged;
        }

        public void Dispose()
        {
            _notifier.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != _propertyName) return;
            _callback?.Invoke();
        }
    }
}