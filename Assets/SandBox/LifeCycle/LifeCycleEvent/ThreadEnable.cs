namespace Game.Runtime
{
    public sealed class ThreadEnable : ThreadBehavior
    {
        private void OnEnable() => Run();
    }
}