namespace NCB.Behavior
{
    public sealed class ThreadMouseOver : ThreadBehavior
    {
        private void OnMouseExit() => Run();
    }
}