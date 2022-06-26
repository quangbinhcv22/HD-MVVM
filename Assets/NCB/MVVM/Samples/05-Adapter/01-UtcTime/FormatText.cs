using TMPro;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    public class FormatText : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private string format = "{0}";

        public void SetText(object source)
        {
            text.SetText(string.Format(format, source));
        }
    }
}