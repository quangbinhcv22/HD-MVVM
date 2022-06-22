using System;
using System.Collections;
using System.Collections.Generic;
using MVVM.Demo;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM.Reflection
{
    [Serializable]
    public class ViewModelProperty
    {
        [SerializeField] [ValueDropdown(nameof(GetAllModelViews))] [BoxGroup] [InlineButton(nameof(OpenAsset), "Open")]
        private string viewModel;

        [SerializeField] [ValueDropdown(nameof(GetAllProperties))] [BoxGroup]
        private string memberName;

        [SerializeField] [ShowIf(nameof(isShowAdapter))] [BoxGroup]
        private DataAdapter.DataAdapter dataAdapter;

        public object ViewModel => ViewModelProvider.Instance.GetViewModel(viewModel);


        public PropertyEndpoint ToEndpoint()
        {
            return new PropertyEndpoint(ViewModel, memberName, dataAdapter);
        }

        public bool HaveNotifyPropertyChange() => ViewModel is INotifyPropertyChanged;

        public EventWatcher ToWatcher(Action callback)
        {
            if (ViewModel is INotifyPropertyChanged iNotifyPropertyChanged)
            {
                return new PropertyChangedWatcher(iNotifyPropertyChanged, memberName, callback);
            }

            return null;
        }


#if UNITY_EDITOR
        [HideInInspector] public bool isShowAdapter = true;
#endif

        public IEnumerable GetAllModelViews() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetAllProperties() => MvvmUtility.GetAllModelViewProperties(viewModel);
        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModel);
    }
}