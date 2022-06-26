using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    [Serializable]
    public class ComponentProperty
    {
        [InfoBox("@ProblemLog", InfoMessageType.Error, VisibleIf = "@HaveProblem")] [SerializeField] [BoxGroup]
        private Component component;

        [SerializeField] [BoxGroup] [ValueDropdown(nameof(GetAllMembers))] [EnableIf(nameof(HaveComponent))]
        private string memberName;

        [SerializeField] [ShowIf(nameof(isShowAdapter))] [BoxGroup]
        private DataAdapter dataAdapter;

        public PropertyEndpoint ToEndpoint()
        {
            return new PropertyEndpoint(component, memberName, dataAdapter);
        }


        #region Editor defense

        public bool HaveProblem => !HaveComponent || !HaveProperty || !IsPropertyValid;

        public string ProblemLog
        {
            get
            {
                if (!HaveComponent) return "<color=yellow>Component</color> can't null";
                if (!HaveProperty) return "<color=yellow>Member Name</color> can't null";
                if (!IsPropertyValid) return $"<color=yellow>{memberName}</color> not exist";

                return null;
            }
        }

        private bool HaveComponent => component != null;
        private bool HaveProperty => !string.IsNullOrEmpty(memberName);
        private bool IsPropertyValid => GetAllMembers().Contains(memberName);


        [HideInInspector] public PropertyAccess requireAccess;

        #endregion


        [HideInInspector] public bool isShowAdapter = true;

        private List<string> GetAllMembers()
        {
            var allowedMembers = MemberTypes.Field | MemberTypes.Property | MemberTypes.Method;

            return component is null
                ? new List<string>()
                : component.GetType().GetMembers().Where(member => allowedMembers.HasFlag(member.MemberType))
                    .OrderBy(member => member.Name).ThenByDescending(member => member.MemberType)
                    .Select(property => property.Name)
                    .Where(n => !(n.Contains("get_") || n.Contains("set_") || n.Contains("add_") ||
                                  n.Contains("remove_"))).ToList();
        }
    }
}