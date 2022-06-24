namespace Game.Runtime
{
    public sealed class ThreadBecameInvisible : ThreadBehavior
    {
        private void OnBecameInvisible() => Run();
    }
}