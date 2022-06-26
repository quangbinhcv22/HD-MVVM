using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using NCB.MVVM;
using NCB.MVVM.Demo;

namespace NCB.DataView
{
    public sealed class ZObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems.Cast<T>())
                {
                    item.PropertyChanged += (_, _) => InvokeEventChange(item);
                }
            }

            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems.Cast<T>())
                {
                    item.PropertyChanged -= (_, _) => InvokeEventChange(item);
                }
            }

            _onValueChange?.Invoke();
        }


        private Action _onValueChange;

        public void AddListener(Action action)
        {
            _onValueChange += action;
        }

        public void RemoveListener(Action action)
        {
            _onValueChange -= action;
        }

        private void InvokeEventChange(T item)
        {
            if (Contains(item)) _onValueChange?.Invoke();
            else item.PropertyChanged -= (_, _) => InvokeEventChange(item);
        }
    }
}