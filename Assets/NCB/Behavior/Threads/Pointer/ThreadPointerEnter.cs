using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadPointerEnter : ThreadBehavior, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => Run();
    }
}