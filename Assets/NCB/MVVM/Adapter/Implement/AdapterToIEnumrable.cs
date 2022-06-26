using System.Collections;
using UnityEngine;

namespace NCB.MVVM
{
    [CreateAssetMenu(menuName = "MVVM/Adapter/ToIEnumerable", fileName = nameof(AdapterToIEnumrable))]
    public class AdapterToIEnumrable : DataAdapter
    {
        public override object Adapting(object input)
        {
            if (input is IEnumerable enumerable) return enumerable;

            return null;
        }
    }
}