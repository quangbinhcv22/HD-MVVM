using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NCB.MVVM
{
    public partial class ComponentProperty
    {
        [HideInInspector] public PropertyAccess requireAccess;

        private bool HaveProblem => !(HaveComponent && HaveProperty && IsPropertyExist && NotPropertyObsolete && IsPassRequireGet && IsPassRequireSet);

        private string ProblemLog
        {
            get
            {
                if (!HaveComponent) return "<color=yellow>Component</color> can't null";
                if (!HaveProperty) return "<color=yellow>Member Name</color> can't null";
                if (!IsPropertyExist) return $"<color=yellow>{memberName}</color> not exist";
                if (!NotPropertyObsolete) return $"<color=yellow>{memberName}</color> is obsolete";
                if (!IsPassRequireGet) return $"<color=yellow>{memberName}</color> haven't getter as require";
                if (!IsPassRequireSet) return $"<color=yellow>{memberName}</color> haven't setter as require";

                return null;
            }
        }

        private bool HaveComponent => component != null;
        private bool HaveProperty => !string.IsNullOrEmpty(memberName);
        private bool IsPropertyExist => RawMembers.Contains(memberName);
        private bool NotPropertyObsolete => ReflectionExtension.NotObsolete(component, memberName);
        
        private bool IsPassRequireGet
        {
            get
            {
                var requireGet = requireAccess.HasFlag(PropertyAccess.Get);
                var canGet = component.GetType().GetMember(memberName).First().CanGet();

                return !requireGet || canGet;
            }
        }

        private bool IsPassRequireSet
        {
            get
            {
                var requireSet = requireAccess.HasFlag(PropertyAccess.Set);
                var canSet = component.GetType().GetMember(memberName).First().CanSet();

                return !requireSet || canSet;
            }
        }

        private List<string> RawMembers
        {
            get
            {
                if (component is null) return new List<string>();
                return component.GetType().GetMembers().Select(member => member.Name).ToList();
            }
        }
    }
}