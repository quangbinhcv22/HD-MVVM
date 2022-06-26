using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadCollisionEnter : ThreadBehavior
    {
        private void OnCollisionEnter(Collision other) => Run();
    }
}