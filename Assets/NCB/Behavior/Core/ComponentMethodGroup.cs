using System;
using System.Collections.Generic;
using UnityEngine;

namespace NCB.Behavior
{
    [Serializable]
    public class ComponentMethodGroup
    {
        [SerializeField] private List<ObjectMethod> events;

        public void Invoke()
        {
            events.ForEach(e => e.Invoke());
        }
    }
}