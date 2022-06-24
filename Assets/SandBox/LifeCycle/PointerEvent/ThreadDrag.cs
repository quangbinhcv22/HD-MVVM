using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class ThreadDrag : ThreadBehavior, IDragHandler
    {
        public void OnDrag(PointerEventData eventData) => Run();
    }
}