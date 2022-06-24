namespace Game.Runtime
{
    public sealed class ThreadDestroy : ThreadBehavior
    {
        private void OnDestroy() => Run();
    }
}