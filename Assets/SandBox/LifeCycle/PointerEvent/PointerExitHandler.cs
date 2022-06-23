using UnityEngine.EventSystems;

namespace Game.Runtime
{
    public sealed class PointerExitHandler : ComponentEventHandler, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData) => InvokeEvent();
    }
}