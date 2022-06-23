using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace MVVM.Reflection
{
    [Serializable]
    public class ComponentEvent
    {
        [SerializeField] [BoxGroup] [DisableInPlayMode]
        private Component component;

        [SerializeField] [ValueDropdown(nameof(GetEvents))] [BoxGroup] [DisableInPlayMode]
        private string eventName;


        public EventWatcher ToWatcher(Action callback)
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

    [Serializable]
    public class UnityEventWatcher : EventWatcher
    {
        private object _owner;
        private string _eventName;
        private Action _callback;

        private UnityEventBinderBase _eventBinder;

        public UnityEventWatcher(object owner, string eventName, Action callback)
        {
            _owner = owner;
            _eventName = eventName;
            _callback = callback;
        }

        public override void Watch()
        {
            var eventMembers = _owner.GetType().GetMember(_eventName);
            var eventMember = eventMembers.First();

            var unityEvent = eventMember switch
            {
                FieldInfo field => field.GetValue(_owner) as UnityEventBase,
                PropertyInfo property => property.GetValue(_owner) as UnityEventBase,
                _ => null,
            };

            _eventBinder = UnityEventBinderFactory.Create(unityEvent, InvokeCallback);
        }

        private void InvokeCallback()
        {
            _callback?.Invoke();
        }

        public override void Dispose()
        {
            if (_eventBinder is null) return;

            _eventBinder.Dispose();
            _eventBinder = null;
        }
    }

    public abstract class EventWatcher : IDisposable
    {
        public abstract void Watch();
        public abstract void Dispose();
    }

    internal abstract class UnityEventBinderBase : IDisposable
    {
        public abstract void Dispose();
    }
}