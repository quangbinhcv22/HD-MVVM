using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadTriggerEnter2D : ThreadBehavior
    {
        private void OnTriggerEnter2D(Collider2D col) => Run();
    }
}