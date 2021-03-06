using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public class ViewModelMethod
    {
        [SerializeField] [ValueDropdown(nameof(GetAllModelViews))] [BoxGroup] [InlineButton(nameof(OpenAsset), "Open")]
        private string viewModel;

        [SerializeField] [ValueDropdown(nameof(GetMethods))] [BoxGroup]
        private string memberName;


        public object ViewModel => ViewModelProvider.Instance.GetViewModel(viewModel);


        public MethodEndpoint ToEndPoint()
        {
            return new MethodEndpoint(ViewModel, memberName);
        }

        
        public IEnumerable GetAllModelViews() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetMethods() => MvvmUtility.GetAllModelViewMethods(viewModel);
        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModel);
    }
}