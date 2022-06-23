using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class DragHandler : ComponentEventHandler, IDragHandler
    {
        public void OnDrag(PointerEventData eventData) => InvokeEvent();
    }
}