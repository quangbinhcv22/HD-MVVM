namespace NCB.Behavior
{
    public sealed class ThreadFixedUpdate : ThreadBehavior
    {
        private void FixedUpdate() => Run();
    }
}