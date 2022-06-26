using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadEverySeconds : ThreadBehavior
    {
        [SerializeField] [Space] private float repeatRate = 1f;
        [SerializeField] private float delay = 0f;
        [SerializeField] private bool runOnDisable;

        private void Awake()
        {
            InvokeRun();
        }

        private void OnEnable()
        {
            if (runOnDisable) InvokeRun();
        }

        private void OnDisable()
        {
            if (runOnDisable) CancelInvoke(nameof(Run));
        }

        private void InvokeRun()
        {
            InvokeRepeating(nameof(Run), delay, repeatRate);
        }
    }
}