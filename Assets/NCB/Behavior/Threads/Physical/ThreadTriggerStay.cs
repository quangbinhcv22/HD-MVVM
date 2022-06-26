using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadTriggerStay : ThreadBehavior
    {
        private void OnTriggerStay(Collider other) => Run();
    }
}