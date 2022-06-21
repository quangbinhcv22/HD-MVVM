using System;
using System.ComponentModel;
using MVVM.Reflection;

namespace MVVM.Demo
{
    public class PropertyChangedWatcher : EventWatcher
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

        public override void Watch()
        {
            _owner.PropertyChanged += OnPropertyChanged;
        }

        public override void Dispose()
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