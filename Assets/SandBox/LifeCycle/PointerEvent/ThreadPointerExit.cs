using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class ThreadPointerExit : ThreadBehavior, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData) => Run();
    }
}