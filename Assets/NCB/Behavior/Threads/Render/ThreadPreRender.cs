namespace NCB.Behavior
{
    public sealed class ThreadPreRender : ThreadBehavior
    {
        private void OnPreRender() => Run();
    }
}