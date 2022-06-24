namespace Game.Runtime
{
    public sealed class ThreadAwake : ThreadBehavior
    {
        private void Awake() => Run();
    }
}