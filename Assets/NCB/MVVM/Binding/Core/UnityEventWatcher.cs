using System;
using System.Linq;
using System.Reflection;
using UnityEngine.Events;

namespace NCB.MVVM
{
    [Serializable]
    public class UnityEventWatcher : IEventWatcher
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

        public void Watch()
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

        public void Dispose()
        {
            if (_eventBinder is null) return;

            _eventBinder.Dispose();
            _eventBinder = null;
        }
    }
}