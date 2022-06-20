using System;
using System.Linq;
using UnityEngine.Events;

namespace MVVM.Reflection
{
    internal static class UnityEventBinderFactory
    {
        public static UnityEventBinderBase Create(UnityEventBase unityEvent, Action action)
        {
            var unityEventType = unityEvent.GetType().BaseType;

            if (unityEventType != null)
            {
                var genericArguments = unityEventType.GetGenericArguments();

                if (genericArguments.Any())
                {
                    var unityEventBinderType = typeof(UnityEventBinder<>).MakeGenericType(genericArguments);
                    return Activator.CreateInstance(unityEventBinderType, unityEvent, action) as UnityEventBinderBase;
                }
            }

            return new UnityEventBinder(unityEvent, action);
        }
    }

    internal class UnityEventBinder : UnityEventBinderBase
    {
        private readonly UnityEvent _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent()
        {
            _action();
        }
    }

    internal class UnityEventBinder<T1> : UnityEventBinderBase
    {
        private readonly UnityEvent<T1> _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent<T1>) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent(T1 arg1)
        {
            _action();
        }
    }

    internal class UnityEventBinder<T1, T2> : UnityEventBinderBase
    {
        private readonly UnityEvent<T1, T2> _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent<T1, T2>) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent(T1 arg1, T2 arg2)
        {
            _action();
        }
    }

    internal class UnityEventBinder<T1, T2, T3> : UnityEventBinderBase
    {
        private readonly UnityEvent<T1, T2, T3> _unityEvent;
        private readonly Action _action;

        public UnityEventBinder(UnityEventBase unityEvent, Action action)
        {
            _unityEvent = (UnityEvent<T1, T2, T3>) unityEvent;
            _unityEvent.AddListener(HandleEvent);

            _action = action;
        }

        public override void Dispose()
        {
            _unityEvent.RemoveListener(HandleEvent);
        }

        private void HandleEvent(T1 arg1, T2 arg2, T3 arg3)
        {
            _action();
        }
    }
}