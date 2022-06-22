using TMPro;
using UnityEngine;

namespace MVVM.Demo.Capcha
{
    public class CaptchaView : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        public void UpdateView(string capcha)
        {
            text.SetText(capcha);
        }
    }
}