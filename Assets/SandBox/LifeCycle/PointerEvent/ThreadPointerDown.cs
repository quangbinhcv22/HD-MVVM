using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class ThreadPointerDown : ThreadBehavior, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData) => Run();
    }
}
