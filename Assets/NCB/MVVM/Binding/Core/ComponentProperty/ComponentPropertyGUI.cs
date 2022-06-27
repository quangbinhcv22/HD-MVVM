using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace NCB.MVVM
{
    public partial class ComponentProperty
    {
        [HideInInspector] public bool isShowAdapter = true;

        private List<string> FilteredMembers
        {
            get
            {
                if (component is null) return new List<string>();
                return component.GetType().GetMembers().Where(PassFilter).Select(member => member.Name).ToList();
            }
        }

        private bool PassFilter(MemberInfo member)
        {
            return member.IsPropertyOrField() && member.NotObsolete() && member.MatchRequire(requireAccess);
        }
    }
}