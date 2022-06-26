using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadCollisionExit2D : ThreadBehavior
    {
        private void OnCollisionExit2D(Collision2D other) => Run();
    }
}