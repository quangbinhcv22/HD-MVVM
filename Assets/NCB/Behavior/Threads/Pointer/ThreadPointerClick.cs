using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadPointerClick : ThreadBehavior, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData) => Run();
    }
}