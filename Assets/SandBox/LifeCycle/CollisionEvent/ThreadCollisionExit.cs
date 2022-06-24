using UnityEngine;

namespace Game.Runtime
{
    public sealed class ThreadCollisionExit : ThreadBehavior
    {
        private void OnCollisionExit(Collision other) => Run();
    }
}