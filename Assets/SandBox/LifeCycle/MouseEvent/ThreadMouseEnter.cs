using System;

namespace Game.Runtime
{
    public sealed class ThreadMouseEnter : ThreadBehavior
    {
        private void OnMouseEnter() => Run();
    }
}