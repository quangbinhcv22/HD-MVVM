namespace NCB.Behavior
{
    public sealed class ThreadBecameVisible : ThreadBehavior
    {
        private void OnBecameVisible() => Run();
    }
}