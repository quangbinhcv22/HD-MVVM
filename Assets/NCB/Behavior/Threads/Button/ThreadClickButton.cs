using UnityEngine;
using UnityEngine.UI;

namespace NCB.Behavior
{
    [RequireComponent(typeof(Button))]
    public sealed class ThreadClickButton : ThreadBehavior
    {
        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(Run);
        }
    }
}