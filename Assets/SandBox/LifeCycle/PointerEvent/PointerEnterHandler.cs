using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class PointerEnterHandler : ComponentEventHandler, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => InvokeEvent();
    }
}