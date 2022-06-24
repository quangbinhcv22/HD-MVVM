using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class ThreadPointerUp : ThreadBehavior, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData) => Run();
    }
}