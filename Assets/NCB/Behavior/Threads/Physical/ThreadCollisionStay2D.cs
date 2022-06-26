using UnityEngine;

namespace NCB.Behavior
{
    public sealed class ThreadCollisionStay2D : ThreadBehavior
    {
        private void OnCollisionStay2D(Collision2D collision) => Run();
    }
}