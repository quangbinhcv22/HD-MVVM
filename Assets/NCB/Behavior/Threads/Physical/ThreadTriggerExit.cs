using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadTriggerExit : ThreadBehavior
    {
        private void OnTriggerExit(Collider other) => Run();
    }
}