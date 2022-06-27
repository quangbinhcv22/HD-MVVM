using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    public partial class ViewModelProperty
    {
        [HideInInspector] public bool isShowAdapter = true;

        public List<ValueDropdownItem<string>> GetAllViewModel() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetAllRawProperties() => MvvmUtility.GetAllModelViewProperties(viewModel);
        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModel);
    }
}