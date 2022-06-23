using UnityEngine;

namespace Game.Runtime
{
    public sealed class CollisionEnterHandler : ComponentEventHandler
    {
        private void OnCollisionEnter(Collision other) => InvokeEvent();
    }
}