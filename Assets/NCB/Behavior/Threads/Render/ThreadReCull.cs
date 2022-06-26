namespace NCB.Behavior
{
    public sealed class ThreadReCull : ThreadBehavior
    {
        private void OnPreCull() => Run();
    }
}