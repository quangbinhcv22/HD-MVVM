namespace Game.Runtime
{
    public sealed class ThreadFixedUpdate : ThreadBehavior
    {
        private void FixedUpdate() => Run();
    }
}