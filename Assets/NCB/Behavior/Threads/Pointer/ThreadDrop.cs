using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadDrop : ThreadBehavior, IDropHandler
    {
        public void OnDrop(PointerEventData eventData) => Run();
    }
}