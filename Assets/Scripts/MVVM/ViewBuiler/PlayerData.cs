using System;
using System.ComponentModel;
using Sirenix.OdinInspector;

namespace MVVM
{
    [Serializable]
    public class MasterPlayerData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly PropertySetter _propertySetter;

        public MasterPlayerData()
        {
            _propertySetter = new PropertySetter(this);
        }

        private string _name;
        private string _password;
        private int _id;

        public string Name
        {
            get => _name;
            set => _propertySetter.SetProperty(ref _name, value, nameof(Name));
        }

        public string Password
        {
            get => _password;
            set => _propertySetter.SetProperty(ref _password, value, nameof(Password));
        }

        public int Id
        {
            get => _id;
            set => _propertySetter.SetProperty(ref _id, value, nameof(Id));
        }
    }


    [Serializable]
    public class PlayerData : INotifyPropertyChanged
    {
        private string _name;
        private string _password;
        private int _id;

        [ShowInInspector]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

        [ShowInInspector]
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, nameof(Password));
        }

        [ShowInInspector]
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, string memberName = null)
        {
            if (storage != null && storage.Equals(value)) return false;

            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));

            return true;
        }


        public override string ToString()
        {
            return $"Name: {Name}, Password: {Password}, ID: {Id}";
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class ObservableAttribute : Attribute
    {
    }

    public class PropertySetter
    {
        private INotifyPropertyChanged _notifyPropertyChanged;

        public PropertySetter(INotifyPropertyChanged notifyPropertyChanged)
        {
            _notifyPropertyChanged = notifyPropertyChanged;
        }

        public bool SetProperty<T>(ref T storage, T value, string memberName = null)
        {
            if (storage != null && storage.Equals(value)) return false;

            storage = value;

            // var a = _notifyPropertyChanged.PropertyChanged.;
            // .PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));

            return true;
        }
    }
}