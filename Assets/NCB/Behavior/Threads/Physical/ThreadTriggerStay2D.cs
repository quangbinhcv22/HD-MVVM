using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadTriggerStay2D : ThreadBehavior
    {
        private void OnTriggerStay2D(Collider2D other) => Run();
    }
}