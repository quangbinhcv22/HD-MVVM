using UnityEngine;

namespace MVVM.DataAdapter
{
    public abstract class DataAdapter : ScriptableObject
    {
        public abstract object Adapting(object input);
    }
}