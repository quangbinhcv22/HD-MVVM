using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class PointerDownHandler : ComponentEventHandler, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData) => InvokeEvent();
    }
}
