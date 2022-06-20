﻿using System.Collections.Generic;
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


        [SerializeField] [Space] private ViewModelProperty sourceProperty;
        [SerializeField] private ComponentEndpoint viewEndpoint;


        [SerializeField] [ShowIf(nameof(HaveSyncFromDest))]
        private ComponentEvent destEvent;

        [SerializeField, Space] private bool keepConnectOnDisable = false;


        private SyncEndpoints _syncEndpoints;
        private readonly List<EventWatcher> _eventWatchers = new List<EventWatcher>();


        public MemberEndpoint ViewEndpoint { get; set; }

        private void Awake()
        {
            // ViewEndpoint = viewEndpoint.ToEndpoint();


            _syncEndpoints = new SyncEndpoints(sourceProperty.ToEndpoint(), viewEndpoint.ToEndpoint());

            // if(mode.HaveSyncFromSource()) _eventWatchers.Add();
            if (HaveSyncFromDest) _eventWatchers.Add(destEvent.ToWatcher(_syncEndpoints.SyncFormDest));
        }

        private void OnEnable()
        {
            // if (mode.HaveSyncFromSource()) _propertySync.SyncFromSource();
            _eventWatchers.ForEach(watcher => watcher.Watch());
        }

        public void OnDisable()
        {
            if (keepConnectOnDisable) return;
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        public void OnDestroy()
        {
            _eventWatchers.ForEach(watcher => watcher.Dispose());
        }

        public void OnValidate()
        {
            if (sourceProperty != null) sourceProperty.isShowAdapter = HaveSyncFromDest;
            if (viewEndpoint != null) viewEndpoint.isShowAdapter = HaveSyncFromSource;
        }
    }
}