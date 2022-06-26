namespace NCB.Behavior
{
    public sealed class ThreadPostRender : ThreadBehavior
    {
        private void OnPostRender() => Run();
    }
}