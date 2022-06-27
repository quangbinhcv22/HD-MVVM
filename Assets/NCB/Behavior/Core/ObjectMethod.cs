using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace NCB.Behavior
{
    [Serializable]
    public class ObjectMethod
    {
        [InfoBox("@NotValidLog", VisibleIf = nameof(IsNotValid), InfoMessageType = InfoMessageType.Error)]
        [SerializeField] [BoxGroup]
        private Object target;

        [SerializeField] [ValueDropdown(nameof(AllMethods))] [EnableIf(nameof(HaveComponent))] [BoxGroup]
        private string methodName;

        private MethodInfo _methodInfo;


        public void Invoke()
        {
            _methodInfo ??= target.GetType().GetMethod(methodName, Array.Empty<Type>());
            _methodInfo?.Invoke(target, null);
        }


        private bool HaveComponent => target != null;

        private IEnumerable AllMethods
        {
            get
            {
                if (target is null) return new List<string>();
                
                return target.GetType().GetMethods().Where(m => m.ReturnType == typeof(void))
                .Where(m => m.GetParameters().Length == 0)
                .Where(member => member.GetCustomAttribute<ObsoleteAttribute>() is null)
                .Select(method => method.Name).Where(n => !(n.Contains("get_") || n.Contains("set_")));
            }
        }

        private bool IsNotValid => !string.IsNullOrEmpty(methodName) && !AllMethods.Cast<string>().Contains(methodName);

        private string NotValidLog => $"<color=yellow>{methodName}</color> is not valid";
    }
}