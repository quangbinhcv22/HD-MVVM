using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public partial class ComponentProperty
    {
        [InfoBox("@ProblemLog", InfoMessageType.Error, VisibleIf = "@HaveProblem")] [BoxGroup] [SerializeField]
        private Component component;

        [ValueDropdown(nameof(FilteredMembers))] [EnableIf(nameof(HaveComponent))] [BoxGroup] [SerializeField]
        private string memberName;

        [ShowIf(nameof(isShowAdapter))] [BoxGroup] [SerializeField]
        private DataAdapter dataAdapter;


        public PropertyEndpoint ToEndpoint() => new PropertyEndpoint(component, memberName, dataAdapter);
    }
}