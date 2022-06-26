using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using UnityEngine;
using INotifyPropertyChanged = NCB.MVVM.INotifyPropertyChanged;

namespace NCB.DataView
{
    public class DataCoreView : MonoBehaviour, global::NCB.MVVM.INotifyPropertyChanged
    {
        [Header("DataType")] [HideLabel] [SerializeField]
        private TypeDefine typeDefine;

        public Type DataType
        {
            get
            {
                if (typeDefine is null)
                {
                    Debug.Log($"typeDefine is null", this);
                    return null;
                }

                return typeDefine.GetType();
            }
        }


        private object _data;

        [ShowPropertyResolver]
        public object Data
        {
            get => _data;
            set
            {
                if (_data is global::NCB.MVVM.INotifyPropertyChanged oldNotifyPropertyChanged)
                {
                    // ReSharper disable once EventUnsubscriptionViaAnonymousDelegate
                    oldNotifyPropertyChanged.PropertyChanged -= (_, _) => NotifyPropertyChanged(nameof(Data));
                }

                _data = value;

                if (_data is INotifyPropertyChanged newNotifyPropertyChanged)
                {
                    newNotifyPropertyChanged.PropertyChanged += (_, _) => NotifyPropertyChanged(nameof(Data));
                }

                NotifyPropertyChanged(nameof(Data));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            // Debug.Log(nameof(NotifyPropertyChanged));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}