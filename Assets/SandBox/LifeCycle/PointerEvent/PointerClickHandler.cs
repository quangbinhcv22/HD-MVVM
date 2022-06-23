using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class PointerClickHandler : ComponentEventHandler, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData) => InvokeEvent();
    }
}