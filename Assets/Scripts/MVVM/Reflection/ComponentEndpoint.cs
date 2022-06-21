using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MVVM.Reflection
{
    [Serializable]
    public class ComponentEndpoint
    {
        [SerializeField] [BoxGroup] private Component component;

        [SerializeField]
        [BoxGroup]
        [ValueDropdown(nameof(GetAllMembers))]
        [EnableIf(nameof(HaveComponent))]
        [InfoBox("@MemberNotValidLog", VisibleIf = nameof(IsMemberNotValid), InfoMessageType = InfoMessageType.Error)]
        private string memberName;


        [SerializeField] [ShowIf(nameof(isShowAdapter))] [BoxGroup]
        private DataAdapter.DataAdapter dataAdapter;

        public MemberEndpoint ToEndpoint()
        {
            return new MemberEndpoint(component, memberName, dataAdapter);
        }


#if UNITY_EDITOR
        [HideInInspector] public bool isShowAdapter = true;
#endif

        private bool HaveComponent() => component != null;

        private List<string> GetAllMembers()
        {
            const MemberTypes allowTypes = MemberTypes.Field | MemberTypes.Property | MemberTypes.Method;

            return component is null
                ? new List<string>()
                : component.GetType().GetMembers().Where(m => allowTypes.HasFlag(m.MemberType))
                    .Select(property => property.Name).ToList();
        }

        private bool IsMemberNotValid => !GetAllMembers().Contains(memberName);
        private string MemberNotValidLog => $"\"{memberName}\" is not valid, please check it.";
    }
}