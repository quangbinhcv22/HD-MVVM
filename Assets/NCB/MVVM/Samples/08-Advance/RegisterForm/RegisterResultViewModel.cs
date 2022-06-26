using NCB.MVVM;

namespace NCB.MVVM.Demo
{
    [Binding]
    public class RegisterResultViewModel : ViewModelBase
    {
        public object OnRegisterCallback { get; set; }

        private string _registerTitle;
        private string _registerContent;


        public string RegisterTitle
        {
            get => _registerTitle;
            set => SetProperty(nameof(RegisterTitle), ref _registerTitle, value);
        }

        public string RegisterContent
        {
            get => _registerContent;
            set => SetProperty(nameof(RegisterContent), ref _registerContent, value);
        }


        public void OnReceiveResult(bool isSuccess, string username)
        {
            if (isSuccess)
            {
                RegisterTitle = "Register Success";
                RegisterContent = $"Thank you <color=purple>{username}</color>\nWe will contact you soon ^^!";
            }
            else
            {
                RegisterTitle = "Register Failed";
                RegisterContent = "Some thing went wrong!";
            }

            NotifyPropertyChanged(nameof(OnRegisterCallback));
        }
    }
}