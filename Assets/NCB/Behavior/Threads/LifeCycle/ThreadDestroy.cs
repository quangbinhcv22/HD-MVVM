namespace NCB.Behavior
{
    public sealed class ThreadDestroy : ThreadBehavior
    {
        private void OnDestroy() => Run();
    }
}