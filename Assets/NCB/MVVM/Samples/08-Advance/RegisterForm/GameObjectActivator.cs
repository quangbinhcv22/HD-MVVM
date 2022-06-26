using UnityEngine;

namespace NCB.MVVM.Demo.RegisterForm
{
    public class GameObjectActivator : MonoBehaviour
    {
        [SerializeField] private GameObject target;

        public void Active()
        {
            target.SetActive(true);
        }
        
        public void DeActive()
        {
            target.SetActive(false);
        }
    }
}