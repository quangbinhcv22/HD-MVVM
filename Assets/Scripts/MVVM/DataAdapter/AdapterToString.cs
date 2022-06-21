using UnityEngine;

namespace MVVM.DataAdapter
{
    [CreateAssetMenu(menuName = "MVVM/Adapter/ToString", fileName = nameof(AdapterToString))]
    public class AdapterToString : DataAdapter
    {
        public override object Adapting(object input)
        {
            return input is null ? "null" : input.ToString();
        }
    }
}