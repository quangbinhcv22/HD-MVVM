namespace NCB.Behavior
{
    public sealed class ThreadWillRenderObject : ThreadBehavior
    {
        private void OnWillRenderObject() => Run();
    }
}