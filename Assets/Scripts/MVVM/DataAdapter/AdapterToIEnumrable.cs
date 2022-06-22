using System.Collections;
using MVVM.DataAdapter;
using UnityEngine;

[CreateAssetMenu(menuName = "MVVM/Adapter/ToIEnumerable", fileName = nameof(AdapterToIEnumrable))]
public class AdapterToIEnumrable : DataAdapter
{
    public override object Adapting(object input)
    {
        if (input is IEnumerable enumerable) return enumerable;
        
        return null;
    }
}