using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace NCB.MVVM
{
    [Serializable]
    public class ComponentEvent
    {
        [SerializeField] [BoxGroup] private Component component;

        [SerializeField] [ValueDropdown(nameof(GetEvents))] [BoxGroup]
        private string eventName;


        public IEventWatcher ToWatcher(Action callback)
        {
            return new UnityEventWatcher(component, eventName, callback);
        }

        public List<string> GetEvents()
        {
            var allowTypes = MemberTypes.Field | MemberTypes.Property;

            if (component is null) return new List<string>();
            return component.GetType().GetMembers().Where(member =>
                    allowTypes.HasFlag(member.MemberType) && member.ReturnType().IsSubclassOf(typeof(UnityEventBase)))
                .Select(member => $"{member.Name}").ToList();
        }
    }
}