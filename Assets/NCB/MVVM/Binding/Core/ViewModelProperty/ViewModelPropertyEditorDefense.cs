using System.Linq;
using UnityEngine;

namespace NCB.MVVM
{
    public partial class ViewModelProperty
    {
        [HideInInspector] public PropertyAccess requireAccess;

        private bool HaveProblem => !(HaveViewModel && IsViewModelExits && HaveProperty && IsPropertyExist);
        // private bool HaveWarning => HaveViewModelProblem && !(NotViewModelObsolete);

        private bool HaveViewModelProblem => !(HaveViewModel && IsViewModelExits);


        private string ProblemLog
        {
            get
            {
                if (!HaveViewModel) return "<color=yellow>View Model</color> can't null";
                if (!IsViewModelExits) return $"<color=yellow>{viewModel}</color> not exist";

                if (!HaveProperty) return "<color=yellow>Member Name</color> can't null";
                if (!IsPropertyExist) return $"<color=yellow>{memberName}</color> not exist";

                return null;
            }
        }

        private string WarningLog
        {
            get
            {
                if (!HaveViewModel) return null;
                if (!NotViewModelObsolete) return $"<color=yellow>{viewModel}</color> is obsolete";
                return null;
            }
        }

        private bool HaveViewModel => !string.IsNullOrEmpty(viewModel);

        private bool IsViewModelExits => GetAllViewModel().Any(vm => vm.Value == viewModel);
        private bool NotViewModelObsolete => HaveViewModel && MvvmUtility.GetViewModelType(viewModel).NotObsolete();


        private bool HaveProperty => !string.IsNullOrEmpty(memberName);

        private bool IsPropertyExist => GetAllRawProperties().Contains(memberName);
        //Not property Obsolete 
    }
}