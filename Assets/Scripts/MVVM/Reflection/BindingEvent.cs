using System.Collections.Generic;
using MVVM.Reflection;
using UnityEngine;

namespace MVVM
{
    public class BindingEvent : MonoBehaviour
    {
        [SerializeField] private ComponentEvent dest;
        [SerializeField] private ViewModelMethod source;

        private readonly List<EventWatcher> _eventWatchers = new List<EventWatcher>();


        private MethodEndpoint _sourceEndPoint;

        private void Awake()
        {
            _sourceEndPoint = source.ToEndPoint();
            _eventWatchers.Add(dest.ToWatcher(_sourceEndPoint.Invoke));
        }

        private void OnEnable()
        {
            _eventWatchers.ForEach(watcher => watcher.Watch());
        }

        private void OnDisable()
        {
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        private void OnDestroy()
        {
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }
    }
}