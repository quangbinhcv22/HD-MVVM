using UnityEngine;

namespace NCB.MVVM
{
    [CreateAssetMenu(menuName = "MVVM/Adapter/ToFormatString", fileName = nameof(AdapterToFormatString))]
    public class AdapterToFormatString : DataAdapter
    {
        [SerializeField] private string format = "{0}";

        public override object Adapting(object input)
        {
            return string.Format(format, input);
        }
    }
}