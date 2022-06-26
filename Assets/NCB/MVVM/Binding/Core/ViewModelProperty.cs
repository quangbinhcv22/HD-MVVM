using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NCB.MVVM.Demo;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public class ViewModelProperty
    {
        [InfoBox("@ProblemLog", InfoMessageType.Error, VisibleIf = "@HaveProblem")]
        [ValueDropdown(nameof(GetAllViewModel))]
        [BoxGroup]
        [SerializeField]
        [InlineButton(nameof(OpenAsset), "Open", ShowIf = "@HaveViewModel && IsViewModelValid")]
        private string viewModel;

        [SerializeField] [ValueDropdown(nameof(GetAllProperties))] [BoxGroup] [EnableIf(nameof(HaveViewModel))]
        private string memberName;

        [SerializeField] [ShowIf(nameof(isShowAdapter))] [BoxGroup]
        private DataAdapter dataAdapter;

        public object ViewModel => ViewModelProvider.Instance.GetViewModel(viewModel);


        #region Editor defense

        private bool HaveProblem => !HaveViewModel || !IsViewModelValid || !HaveProperty || !IsPropertyValid;

        private string ProblemLog
        {
            get
            {
                if (!HaveViewModel) return "<color=yellow>View Model</color> can't null";
                if (!IsViewModelValid) return $"<color=yellow>{viewModel}</color> not exist";
                if (!HaveProperty) return "<color=yellow>Member Name</color> can't null";
                if (!IsPropertyValid) return $"<color=yellow>{memberName}</color> not exist";

                return null;
            }
        }

        private bool HaveViewModel => !string.IsNullOrEmpty(viewModel);
        private bool IsViewModelValid => GetAllViewModel().Any(vm => vm.Value == viewModel);
        private bool HaveProperty => !string.IsNullOrEmpty(memberName);
        private bool IsPropertyValid => GetAllProperties().Contains(memberName);


        [HideInInspector] public PropertyAccess requireAccess;

        #endregion


        public PropertyEndpoint ToEndpoint()
        {
            return new PropertyEndpoint(ViewModel, memberName, dataAdapter);
        }

        public bool HaveNotifyPropertyChange() => ViewModel is INotifyPropertyChanged;

        public IEventWatcher ToWatcher(Action callback)
        {
            if (ViewModel is INotifyPropertyChanged iNotifyPropertyChanged)
            {
                return new PropertyChangedWatcher(iNotifyPropertyChanged, memberName, callback);
            }

            return null;
        }


        [HideInInspector] public bool isShowAdapter = true;

        public List<ValueDropdownItem<string>> GetAllViewModel() => MvvmUtility.GetAllModelViewsName();
        public List<string> GetAllProperties() => MvvmUtility.GetAllModelViewProperties(viewModel);
        public void OpenAsset() => MvvmUtility.OpenViewModelAsset(viewModel);
    }
}