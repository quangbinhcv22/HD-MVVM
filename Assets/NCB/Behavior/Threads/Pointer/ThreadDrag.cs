using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadDrag : ThreadBehavior, IDragHandler
    {
        public void OnDrag(PointerEventData eventData) => Run();
    }
}