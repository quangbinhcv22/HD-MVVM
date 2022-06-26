namespace NCB.Behavior
{
    public sealed class ThreadEnable : ThreadBehavior
    {
        private void OnEnable() => Run();
    }
}