namespace Game.Runtime
{
    public sealed class ThreadBecameVisible : ThreadBehavior
    {
        private void OnBecameVisible() => Run();
    }
}