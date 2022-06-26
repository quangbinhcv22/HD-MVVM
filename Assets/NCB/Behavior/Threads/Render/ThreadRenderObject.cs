namespace NCB.Behavior
{
    public sealed class ThreadRenderObject : ThreadBehavior
    {
        private void OnRenderObject() => Run();
    }
}