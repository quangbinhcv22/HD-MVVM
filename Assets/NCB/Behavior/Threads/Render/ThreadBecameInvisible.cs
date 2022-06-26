namespace NCB.Behavior
{
    public sealed class ThreadBecameInvisible : ThreadBehavior
    {
        private void OnBecameInvisible() => Run();
    }
}