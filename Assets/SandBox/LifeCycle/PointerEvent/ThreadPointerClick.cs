using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class ThreadPointerClick : ThreadBehavior, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData) => Run();
    }
}