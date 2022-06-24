namespace Game.Runtime
{
    public sealed class ThreadMouseDown : ThreadBehavior
    {
        private void OnMouseDown() => Run();
    }
}