using System;
using NCB.MVVM.Demo;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public partial class ViewModelProperty
    {
        [InfoBox("@ProblemLog", InfoMessageType.Error, VisibleIf = "@HaveProblem")]
        // [InfoBox("@WarningLog", InfoMessageType.Warning, VisibleIf = "@HaveWarning")]
        [ValueDropdown(nameof(GetAllViewModel))]
        [BoxGroup]
        [SerializeField]
        [InlineButton(nameof(OpenAsset), "Open", ShowIf = "@!HaveViewModelProblem")]
        private string viewModel;

        [SerializeField] [ValueDropdown(nameof(GetAllRawProperties))] [BoxGroup] [EnableIf("@!HaveViewModelProblem")]
        private string memberName;

        [SerializeField] [ShowIf(nameof(isShowAdapter))] [BoxGroup]
        private DataAdapter dataAdapter;

        public object ViewModel => ViewModelProvider.Instance.GetViewModel(viewModel);
        
        public bool HaveNotifyPropertyChange() => ViewModel is INotifyPropertyChanged;
        public PropertyEndpoint ToEndpoint() => new PropertyEndpoint(ViewModel, memberName, dataAdapter);


        public IEventWatcher ToWatcher(Action callback)
        {
            if (ViewModel is INotifyPropertyChanged iNotifyPropertyChanged)
            {
                return new PropertyChangedWatcher(iNotifyPropertyChanged, memberName, callback);
            }

            return null;
        }
    }
}