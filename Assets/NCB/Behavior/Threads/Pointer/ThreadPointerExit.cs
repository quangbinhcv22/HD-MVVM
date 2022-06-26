using UnityEngine.EventSystems;

namespace NCB.Behavior
{
    public sealed class ThreadPointerExit : ThreadBehavior, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData) => Run();
    }
}