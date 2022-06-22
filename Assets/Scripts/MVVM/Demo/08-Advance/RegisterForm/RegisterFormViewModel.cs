using System.Collections.Generic;
using MVVM.ModelView;

namespace MVVM.Demo
{
    [Binding]
    public class RegisterFormViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private bool _isAgreeTerm;

        public string Username
        {
            get => _username;
            set => SetProperty(nameof(Username), ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(nameof(Password), ref _password, value);
        }

        public bool IsAgreeTerm
        {
            get => _isAgreeTerm;
            set => SetProperty(nameof(IsAgreeTerm), ref _isAgreeTerm, value);
        }

        public bool CanRegister => !string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_password) && _isAgreeTerm;


        public RegisterFormViewModel()
        {
            PropertyDependencies = new Dictionary<string, string[]>()
            {
                {nameof(Username), new[] {nameof(CanRegister)}},
                {nameof(Password), new[] {nameof(CanRegister)}},
                {nameof(IsAgreeTerm), new[] {nameof(CanRegister)}},
            };
        }

        public void Register()
        {
            var registerResultViewModel = ViewModelProvider.Instance.GetViewModel<RegisterResultViewModel>();
            registerResultViewModel.OnReceiveResult(CanRegister, Username);
        }
    }
}