using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadCollisionExit : ThreadBehavior
    {
        private void OnCollisionExit(Collision other) => Run();
    }
}