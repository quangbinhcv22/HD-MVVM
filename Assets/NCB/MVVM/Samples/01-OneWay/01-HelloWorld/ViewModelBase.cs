using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected Dictionary<string, string[]> PropertyDependencies = new Dictionary<string, string[]>();

        protected bool SetProperty<T>(string memberName, ref T storage, T value)
        {
            if (storage != null && storage.Equals(value)) return false;

            storage = value;

            NotifyPropertyChanged(memberName);

            if (memberName != null && PropertyDependencies.ContainsKey(memberName))
            {
                foreach (var dependencyMember in PropertyDependencies[memberName])
                {
                    NotifyPropertyChanged(dependencyMember);
                }
            }

            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ViewModelMonoBehaviorBase : MonoBehaviour, INotifyPropertyChanged
    {
        protected Dictionary<string, string[]> PropertyDependencies = new Dictionary<string, string[]>();

        protected bool SetProperty<T>(string memberName, ref T storage, T value)
        {
            if (storage != null && storage.Equals(value)) return false;

            storage = value;

            NotifyPropertyChanged(memberName);

            if (memberName != null && PropertyDependencies.ContainsKey(memberName))
            {
                foreach (var dependencyMember in PropertyDependencies[memberName])
                {
                    NotifyPropertyChanged(dependencyMember);
                }
            }

            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}