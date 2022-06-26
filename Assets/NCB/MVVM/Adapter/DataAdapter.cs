using UnityEngine;

namespace NCB.MVVM
{
    public abstract class DataAdapter : ScriptableObject
    {
        public abstract object Adapting(object input);
    }
}