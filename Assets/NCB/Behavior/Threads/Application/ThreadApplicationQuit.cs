namespace NCB.Behavior
{
    public sealed class ThreadApplicationQuit : ThreadBehavior
    {
        private void OnApplicationQuit() => Run();
    }
}