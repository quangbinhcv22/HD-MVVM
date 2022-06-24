using System;
using UnityEngine;

namespace Game.Runtime
{
    [Serializable]
    public class BehaviorThread
    {
        [SerializeField]
        private ComponentMethod[] behaviors;

        public void Run()
        {
            foreach (var behavior in behaviors)
            {
                behavior.Invoke();
            }
        }
    }
}