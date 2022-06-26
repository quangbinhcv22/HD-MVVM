using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    public class BindingEvent : MonoBehaviour
    {
        [Header("Dest Event")] [HideLabel] [SerializeField]
        private ComponentEvent destEvent;

        [Header("Source Callback")] [HideLabel] [SerializeField]
        private ViewModelMethod sourceCallback;

        
        private MethodEndpoint _sourceEndPoint;
        private readonly List<IEventWatcher> _eventWatchers = new();

        
        private void Awake()
        {
            _sourceEndPoint = sourceCallback.ToEndPoint();
            _eventWatchers.Add(destEvent.ToWatcher(_sourceEndPoint.Invoke));
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