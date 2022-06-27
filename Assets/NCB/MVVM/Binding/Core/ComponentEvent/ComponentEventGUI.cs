using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.Events;

namespace NCB.MVVM
{
    public partial class ComponentEvent
    {
        private List<string> FilteredEvents
        {
            get
            {
                if (component is null) return new List<string>();
                return component.GetType().GetMembers().Where(PassFilter).Select(member => member.Name).ToList();
            }
        }

        private bool PassFilter(MemberInfo member)
        {
            return member.IsPropertyOrField() && member.NotObsolete() &&
                   member.ReturnType().IsSubclassOf(typeof(UnityEventBase));
        }
    }
}