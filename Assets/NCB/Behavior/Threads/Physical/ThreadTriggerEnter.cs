using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadTriggerEnter : ThreadBehavior
    {
        private void OnTriggerEnter(Collider other) => Run();
    }
}