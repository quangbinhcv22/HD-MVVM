namespace Game.Runtime
{
    public sealed class ThreadMouseExit : ThreadBehavior
    {
        private void OnMouseExit() => Run();
    }
}