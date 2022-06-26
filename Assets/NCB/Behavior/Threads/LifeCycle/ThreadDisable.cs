namespace NCB.Behavior
{
    public sealed class ThreadDisable : ThreadBehavior
    {
        private void OnDisable() => Run();
    }
}