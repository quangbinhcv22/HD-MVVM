using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    public class ViewModelProvider : MonoBehaviour
    {
        [ShowInInspector] private List<object> _componentViewModels = new();
        [ShowInInspector] private List<object> _pureViewModels = new();

        private static ViewModelProvider _instance;

        public static ViewModelProvider Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new GameObject(nameof(ViewModelProvider)).AddComponent<ViewModelProvider>();
                    DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }

        public object GetViewModel(string viewModelName)
        {
            var viewModelType = GetViewModelType(viewModelName);
            var isComponent = viewModelType.IsSubclassOf(typeof(Component));

            return isComponent ? GetViewModelInstance(viewModelType) : GetPureViewModel(viewModelType);
        }

        public T GetViewModel<T>()
        {
            var viewModelType = typeof(T);
            var isComponent = viewModelType.IsSubclassOf(typeof(Component));

            return (T) (isComponent ? GetViewModelInstance(viewModelType) : GetPureViewModel(viewModelType));
        }

        private static Type GetViewModelType(string viewModelName)
        {
            return Type.GetType(viewModelName);
        }

        private object GetViewModelInstance(Type viewModelType)
        {
            var viewModel = _componentViewModels.Find(viewModel => viewModel.GetType() == viewModelType);
            if (viewModel is null) _componentViewModels.Add(viewModel = gameObject.AddComponent(viewModelType));

            return viewModel;
        }

        private object GetPureViewModel(Type viewModelType)
        {
            var pureViewModel = _pureViewModels.Find(model => model.GetType() == viewModelType);
            if (pureViewModel is null) _pureViewModels.Add(pureViewModel = Activator.CreateInstance(viewModelType));

            return pureViewModel;
        }
    }
}