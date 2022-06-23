using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    [Serializable]
    public class ComponentMethodGroup
    {
        [SerializeField] private List<ComponentMethod> events;

        public void Invoke()
        {
            events.ForEach(e => e.Invoke());
        }
    }
}