using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Runtime
{
    [HideMonoScript]
    public class ComponentEventHandler : MonoBehaviour
    {
        [SerializeField] [HideLabel] [Space] [DisableInPlayMode]
        private ComponentMethodGroup events;

        public void InvokeEvent()
        {
            events.Invoke();
        }
    }
}