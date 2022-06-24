using UnityEngine;

namespace Game.Runtime
{
    public sealed class ThreadCollisionEnter : ThreadBehavior
    {
        private void OnCollisionEnter(Collision other) => Run();
    }
}