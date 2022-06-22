using System.Collections.Generic;
using MVVM.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM
{
    public class BindingData : MonoBehaviour
    {
        private bool HaveSyncFromSource => mode.HaveSyncFromSource();
        private bool HaveSyncFromDest => mode.HaveSyncFromDest();


        [SerializeField] private BindingMode mode;


        [SerializeField] [Space] [Header("Source")] [HideLabel]
        private ViewModelProperty source;

        [SerializeField] [Header("Dest")] [HideLabel]
        private ComponentEndpoint dest;

        [SerializeField] [ShowIf(nameof(HaveSyncFromDest))] [Header("Dest Event")] [HideLabel]
        private ComponentEvent destEvent;


        [SerializeField, Space] private bool autoBindingOnEnable = true;
        [SerializeField] private bool keepBindingOnDisable;


        private SyncEndpoints _syncEndpoints;
        private readonly List<EventWatcher> _eventWatchers = new List<EventWatcher>();


        private void Awake()
        {
            _syncEndpoints = new SyncEndpoints(source.ToEndpoint(), dest.ToEndpoint());

            if (mode.HaveSyncFromSource() && source.HaveNotifyPropertyChange()) _eventWatchers.Add(source.ToWatcher(_syncEndpoints.SyncFormSource));
            if (HaveSyncFromDest) _eventWatchers.Add(destEvent.ToWatcher(_syncEndpoints.SyncFormDest));
        }

        private void OnEnable()
        {
            if (autoBindingOnEnable && mode.HaveSyncFromSource()) _syncEndpoints.SyncFormSource();
            _eventWatchers.ForEach(watcher => watcher.Watch());
        }

        public void OnDisable()
        {
            if (keepBindingOnDisable) return;
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        public void OnDestroy()
        {
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        public void OnValidate()
        {
            if (source != null) source.isShowAdapter = HaveSyncFromDest;
            if (dest != null) dest.isShowAdapter = HaveSyncFromSource;
        }
    }
}