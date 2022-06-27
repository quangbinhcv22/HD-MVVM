using NCB.Behavior;
using NCB.MVVM;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class ThreadCustomEvent : ThreadBehavior
{
    [Header("Event")] [HideLabel] [SerializeField]
    private ComponentEvent @event;

    private IEventWatcher _watcher;

    private void Awake()
    {
        _watcher = @event.ToWatcher(Run);
        _watcher.Watch();
    }

    private void OnDestroy()
    {
        _watcher.Dispose();
    }
}