using UnityEngine;

namespace MVVM.Demo.Capcha
{
    [CreateAssetMenu(menuName = "MVVM/Adapter/CaptchaResultToColor", fileName = nameof(AdapterCaptchaResultToColor))]
    public class AdapterCaptchaResultToColor : DataAdapter.DataAdapter
    {
        [SerializeField] private Color correct = Color.green;
        [SerializeField] private Color incorrect = Color.red;
        [SerializeField] private Color other = Color.white;

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