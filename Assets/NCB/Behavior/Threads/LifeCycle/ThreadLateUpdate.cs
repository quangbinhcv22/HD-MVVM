namespace NCB.Behavior
{
    public sealed class ThreadLateUpdate : ThreadBehavior
    {
        private void LateUpdate() => Run();
    }
}