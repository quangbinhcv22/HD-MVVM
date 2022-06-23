using UnityEngine;

namespace Game.Runtime
{
    public sealed class CollisionExitHandler : ComponentEventHandler
    {
        private void OnCollisionExit(Collision other) => InvokeEvent();
    }
}