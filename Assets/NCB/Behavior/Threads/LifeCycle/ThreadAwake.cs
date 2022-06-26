namespace NCB.Behavior
{
    public sealed class ThreadAwake : ThreadBehavior
    {
        private void Awake() => Run();
    }
}