using UnityEngine;

namespace NCB.MVVM.Demo.Capcha
{
    [CreateAssetMenu(menuName = "MVVM/Adapter/CaptchaResultLocalize", fileName = nameof(AdapterCaptchaResultLocalize))]
    public class AdapterCaptchaResultLocalize : NCB.MVVM.DataAdapter
    {
        [SerializeField] private string correct = "Captcha match";
        [SerializeField] private string incorrect = "Captcha is not valid";
        [SerializeField] private string other = "unknown";

        public override object Adapting(object input)
        {
            if (input is CaptchaResult captchaResult)
            {
                return captchaResult switch
                {
                    CaptchaResult.Correct => correct,
                    CaptchaResult.Incorrect => incorrect,
                    _ => other,
                };
            }

            return other;
        }
    }
}