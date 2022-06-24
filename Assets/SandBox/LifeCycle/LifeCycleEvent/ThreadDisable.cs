namespace Game.Runtime
{
    public sealed class ThreadDisable : ThreadBehavior
    {
        private void OnDisable() => Run();
    }
}