using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class PointerUpHandler : ComponentEventHandler, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData) => InvokeEvent();
    }
}