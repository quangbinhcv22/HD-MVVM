using System;
using MVVM.ModelView;

namespace MVVM.Demo.Capcha
{
    [Binding]
    public class CaptchaViewModel : ViewModelBase
    {
        private string _captcha;
        private string _captchaInput;
        
        public string Captcha
        {
            get => _captcha;
            set => SetProperty(nameof(Captcha), ref _captcha, value);
        }

        public string CaptchaInput
        {
            get => _captchaInput;
            set => SetProperty(nameof(CaptchaInput), ref _captchaInput, value);
        }

        public CaptchaResult Result
        {
            get
            {
                if (string.IsNullOrEmpty(Captcha) || string.IsNullOrEmpty(CaptchaInput)) return CaptchaResult.Incorrect;
                return Captcha.ToUpper() == CaptchaInput.ToUpper() ? CaptchaResult.Correct : CaptchaResult.Incorrect;
            }
        }

        public CaptchaViewModel()
        {
            PropertyDependencies.Add(nameof(Captcha), new[] {nameof(Result)});
            PropertyDependencies.Add(nameof(CaptchaInput), new[] {nameof(Result)});

            GenNewCaptcha();
        }

        public void GenNewCaptcha()
        {
            Captcha = FakeCaptchaService.GenCode();
        }
    }

    public static class FakeCaptchaService
    {
        public static string GenCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }

    public enum CaptchaResult
    {
        Correct = 1,
        Incorrect = 2,
    }
}