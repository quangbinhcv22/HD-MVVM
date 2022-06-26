using Sirenix.OdinInspector;
using UnityEngine;

namespace NCB.MVVM
{
    public class RunViewModelMethod : MonoBehaviour
    {
        [SerializeField] [HideLabel] private ViewModelMethod method;


        private MethodEndpoint _endpoint;

        private MethodEndpoint Endpoint
        {
            get
            {
                _endpoint ??= method.ToEndPoint();
                return _endpoint;
            }
        }


        public void Run()
        {
            Endpoint.Invoke();
        }
    }
}