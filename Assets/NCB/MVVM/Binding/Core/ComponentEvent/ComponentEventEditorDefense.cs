using System.Collections.Generic;
using System.Linq;

namespace NCB.MVVM
{
    public partial class ComponentEvent
    {
        private bool HaveProblem => !(HaveComponent && HaveEvent && IsEventExist && NotEventObsolete);

        private string ProblemLog
        {
            get
            {
                if (!HaveComponent) return "<color=yellow>Component</color> can't null";
                if (!HaveEvent) return "<color=yellow>Event Name</color> can't null";
                if (!IsEventExist) return $"<color=yellow>{eventName}</color> not exist";
                if (!NotEventObsolete) return $"<color=yellow>{eventName}</color> is obsolete";

                return null;
            }
        }

        private bool HaveComponent => component != null;
        private bool HaveEvent => !string.IsNullOrEmpty(eventName);
        private bool IsEventExist => RawEvents.Contains(eventName);
        private bool NotEventObsolete => ReflectionExtension.NotObsolete(component, eventName);


        private List<string> RawEvents
        {
            get
            {
                if (component is null) return new List<string>();
                return component.GetType().GetMembers().Select(member => member.Name).ToList();
            }
        }
    }
}