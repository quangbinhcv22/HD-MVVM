namespace Game.Runtime
{
    public sealed class BecameVisibleHandler : ComponentEventHandler
    {
        private void OnBecameVisible() => InvokeEvent();
    }
}