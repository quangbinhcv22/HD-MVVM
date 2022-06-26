using System;
using System.ComponentModel;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public class Alpha : INotifyPropertyChanged
    {
        [SerializeField] public Beta beta;
        [SerializeField] public string ana;


        public Alpha()
        {
            // beta.PropertyChanged += 
        }
        
        public Beta Beta
        {
            get => beta;
            set => SetProperty(ref beta, value, nameof(Beta));
        }
        
        public string Ana
        {
            get => ana;
            set => SetProperty(ref ana, value, nameof(Ana));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, string memberName = null)
        {
            if (storage != null && storage.Equals(value)) return false;

            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));

            return true;
        }
    }

    [Serializable]
    public class Beta
    {
        public Omega omega;
        public string b2;
        
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
    }


    [Serializable]
    public class PlayerData : INotifyPropertyChanged
    {
        [SerializeField] private string _name;
        [SerializeField] private string _password;
        [SerializeField] private int _id;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, nameof(Password));
        }

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