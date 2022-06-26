using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadTriggerExit2D : ThreadBehavior
    {
        private void OnTriggerExit2D(Collider2D other) => Run();
    }
}