using System.Collections.Generic;

namespace NCB.MVVM.Demo
{
    [Binding]
    public class HelloWorldViewModel
    {
        public string HelloText => "Hello World!";
    }


    public class FormViewModel : ViewModelBase
    {
        private string _mail;

        public string Mail
        {
            get => _mail;
            set => SetProperty(nameof(Mail), ref _mail, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(nameof(Password), ref _password, value);
        }


        public bool HaveMail => !string.IsNullOrEmpty(Mail);
        public bool IsValidMail => HaveMail && Mail.Contains('@');

        public bool HavePassword => !string.IsNullOrEmpty(Password);
        public int PasswordLength => HavePassword ? Password.Length : default;

        public bool CanSign => HaveMail && HavePassword;


        public FormViewModel()
        {
            PropertyDependencies = new Dictionary<string, string[]>()
            {
                {nameof(Mail), new[] {nameof(HaveMail), nameof(IsValidMail), nameof(CanSign)}},
                {nameof(Password), new[] {nameof(HavePassword), nameof(PasswordLength), nameof(CanSign)}},
            };
        }
    }

    public class TraditionalFormViewModel : ViewModelBase
    {
        // private string _mail;
        //
        // public string Mail
        // {
        //     get => _mail;
        //     set
        //     {
        //         SetProperty(ref _mail, value, Mail);
        //
        //         NotifyPropertyChanged(nameof(HaveMail));
        //         NotifyPropertyChanged(nameof(IsValidMail));
        //         NotifyPropertyChanged(nameof(CanSign));
        //     }
        // }
        //
        // private string _password;
        //
        // public string Password
        // {
        //     get => _password;
        //     set
        //     {
        //         SetProperty(ref _password, value, Password);
        //
        //         NotifyPropertyChanged(nameof(HavePassword));
        //         NotifyPropertyChanged(nameof(PasswordLength));
        //         NotifyPropertyChanged(nameof(CanSign));
        //     }
        // }
        //
        //
        // public bool HaveMail => !string.IsNullOrEmpty(Mail);
        // public bool IsValidMail => HaveMail && Mail.Contains('@');
        //
        // public bool HavePassword => !string.IsNullOrEmpty(Password);
        // public int PasswordLength => HavePassword ? Password.Length : default;
        //
        // public bool CanSign => HaveMail && HavePassword;
    }
}