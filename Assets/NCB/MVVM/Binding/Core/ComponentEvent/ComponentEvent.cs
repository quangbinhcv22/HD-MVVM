using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public partial class ComponentEvent
    {
        [InfoBox("@ProblemLog", InfoMessageType.Error, VisibleIf = "@HaveProblem")] [BoxGroup] [SerializeField]
        private Component component;

        [ValueDropdown(nameof(FilteredEvents))] [EnableIf(nameof(HaveComponent))] [BoxGroup] [SerializeField]
        private string eventName;


        public IEventWatcher ToWatcher(Action callback) => new UnityEventWatcher(component, eventName, callback);
    }
}