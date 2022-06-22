using System;
using System.ComponentModel;
using Sirenix.OdinInspector;

namespace MVVM
{
    [Serializable]
    public class Alpha
    {
        public Beta beta;

    }
    
    [Serializable]
    public class Beta
    {
        public Omega omega;
        public int b2;
    }
    
    [Serializable]
    public class Omega
    {
        public string o1;
        public int o2;
        public Zora zora;
    }

    [Serializable]
    public class Zora
    {
        public float z1;
        public int z2;
        public Omega z3;
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