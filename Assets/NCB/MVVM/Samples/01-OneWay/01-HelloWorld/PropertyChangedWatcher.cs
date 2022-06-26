using System;
using System.ComponentModel;

namespace NCB.MVVM.Demo
{
    public class PropertyChangedWatcher : IEventWatcher
    {
        private readonly INotifyPropertyChanged _owner;
        private readonly string _propertyName;
        private readonly Action _callback;

        public PropertyChangedWatcher(INotifyPropertyChanged owner, string propertyName, Action callback)
        {
            _owner = owner;
            _propertyName = propertyName;
            _callback = callback;
        }

        public void Watch()
        {
            _owner.PropertyChanged += OnPropertyChanged;
        }

        public void Dispose()
        {
            _owner.PropertyChanged -= OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != _propertyName) return;
            _callback?.Invoke();
        }
    }
}