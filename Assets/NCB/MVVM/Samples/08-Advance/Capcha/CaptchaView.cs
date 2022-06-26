using TMPro;
using UnityEngine;

namespace NCB.MVVM.Demo.Capcha
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