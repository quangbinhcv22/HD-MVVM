namespace NCB.Behavior
{
    public sealed class ThreadMouseExit : ThreadBehavior
    {
        private void OnMouseExit() => Run();
    }
}