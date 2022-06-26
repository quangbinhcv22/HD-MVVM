using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadEveryFrames : ThreadBehavior
    {
        [SerializeField] [Space] private int repeatRate = 1;

        private void Update()
        {
            if (Time.frameCount % repeatRate == default) Run();
        }
    }
}