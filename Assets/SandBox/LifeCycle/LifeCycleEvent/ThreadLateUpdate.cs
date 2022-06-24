namespace Game.Runtime
{
    public sealed class ThreadLateUpdate : ThreadBehavior
    {
        private void LateUpdate() => Run();
    }
}