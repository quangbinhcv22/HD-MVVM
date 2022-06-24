namespace Game.Runtime
{
    public sealed class ThreadMouseOver : ThreadBehavior
    {
        private void OnMouseExit() => Run();
    }
}