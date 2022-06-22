using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM.ViewBuilder
{
    public class DataCoreView : MonoBehaviour, INotifyPropertyChanged
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
                _data = value;
                NotifyPropertyChanged(nameof(Data));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            Debug.Log(nameof(NotifyPropertyChanged));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}