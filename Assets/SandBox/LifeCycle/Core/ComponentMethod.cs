using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Runtime
{
    [Serializable]
    public class ComponentMethod
    {
        [SerializeField] private Component component;

        [SerializeField] [ValueDropdown(nameof(AllMethods))] [EnableIf(nameof(HaveComponent))]
        private string methodName;


        private MethodInfo methodInfo;


        public void Invoke()
        {
            methodInfo ??= component.GetType().GetMethod(methodName);
            methodInfo?.Invoke(component, null);
        }


        private bool HaveComponent => component != null;

        private IEnumerable AllMethods
        {
            get
            {
                if (component is null) return new List<string>();

                return component.GetType().GetMethods().Where(m => m.ReturnType == typeof(void))
                    .Where(m => m.GetParameters().Length == 0)
                    .Select(method => method.Name).Where(n => !(n.Contains("get_") || n.Contains("set_")));
            }
        }
    }
}