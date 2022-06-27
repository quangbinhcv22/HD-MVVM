using TMPro;
using UnityEngine;

namespace NCB.MVVM.Demo
{
    public class FormatText : MonoBehaviour
    {
        [SerializeField] private TMP_Text textMesh;
        [SerializeField] private string format = "{0}";

        public object text
        {
            get => textMesh.text;
            set => textMesh.SetText(string.Format(format, value));
        }
    }
}