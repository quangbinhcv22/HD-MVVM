using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [HideMonoScript]
    public class BindingData : MonoBehaviour
    {
        [SerializeField] [Space] private BindingMode mode;

        [Header("Source")] [HideLabel] [SerializeField]
        private ViewModelProperty source;

        [Header("Dest")] [HideLabel] [SerializeField]
        private ComponentProperty dest;

        [Header("Dest Event")] [HideLabel] [ShowIf(nameof(HaveSyncFromDest))] [SerializeField]
        private ComponentEvent destEvent;

        [Space] [SerializeField] private bool autoBindingOnEnable = true;
        [SerializeField] private bool keepBindingOnDisable;


        private SyncEndpoints _syncEndpoints;
        private readonly List<IEventWatcher> _eventWatchers = new();

        private bool HaveSyncFromSource => mode.HaveSyncFromSource();
        private bool HaveSyncFromDest => mode.HaveSyncFromDest();


        private void Awake()
        {
            _syncEndpoints = new SyncEndpoints(source.ToEndpoint(), dest.ToEndpoint());

            if (HaveSyncFromSource && source.HaveNotifyPropertyChange())
            {
                _eventWatchers.Add(source.ToWatcher(_syncEndpoints.SyncFormSource));
            }

            if (HaveSyncFromDest)
            {
                _eventWatchers.Add(destEvent.ToWatcher(_syncEndpoints.SyncFormDest));
            }
        }

        private void OnEnable()
        {
            if (autoBindingOnEnable && HaveSyncFromSource)
            {
                _syncEndpoints.SyncFormSource();
            }

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
            if (source != null)
            {
                source.isShowAdapter = HaveSyncFromDest;
                source.requireAccess = mode.GetSourceRequireAccess();
            }

            if (dest != null)
            {
                dest.isShowAdapter = HaveSyncFromSource;
                dest.requireAccess = mode.GetDestRequireAccess();
            }
        }
    }
}