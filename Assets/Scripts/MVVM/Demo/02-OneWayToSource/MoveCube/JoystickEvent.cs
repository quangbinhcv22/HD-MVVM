using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MVVM.Demo.MoveCube
{
    public class JoystickEvent : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public UnityEvent onDrag;
    
        public void OnDrag(PointerEventData eventData)
        {
            onDrag?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onDrag?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onDrag?.Invoke();
        }
    }
}
