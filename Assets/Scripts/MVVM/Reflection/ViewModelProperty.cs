using System;
using System.Collections.Generic;
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


        public MemberEndpoint ToEndpoint()
        {
            return new MemberEndpoint(ViewModel, memberName, dataAdapter);
        }

#if UNITY_EDITOR
        [HideInInspector] public bool isShowAdapter = true;
#endif

        public List<string> GetAllModelViews() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetAllProperties() => MvvmUtility.GetAllModelViewProperties(viewModel);
        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModel);
    }
}