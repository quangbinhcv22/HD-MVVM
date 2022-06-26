using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadCollisionStay : ThreadBehavior
    {
        private void OnCollisionStay(Collision collisionInfo) => Run();
    }
}