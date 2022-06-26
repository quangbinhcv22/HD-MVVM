using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadPointerUp : ThreadBehavior, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData) => Run();
    }
}