using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadCollisionEnter2D : ThreadBehavior
    {
        private void OnCollisionEnter2D(Collision2D col) => Run();
    }
}