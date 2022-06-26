using System;
using UnityEngine;

namespace NCB.Behavior
{
    [Serializable]
    public class BehaviorThread
    {
        [SerializeField] private ObjectMethod[] behaviors;

        public void Run()
        {
            foreach (var behavior in behaviors)
            {
                behavior.Invoke();
            }
        }
    }
}