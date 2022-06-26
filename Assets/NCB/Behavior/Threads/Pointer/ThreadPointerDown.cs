using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadPointerDown : ThreadBehavior, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData) => Run();
    }
}
