using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class ThreadPointerEnter : ThreadBehavior, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => Run();
    }
}