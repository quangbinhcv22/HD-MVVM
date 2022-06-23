namespace Game.Runtime
{
    public sealed class BecameInvisibleHandler : ComponentEventHandler
    {
        private void OnBecameInvisible() => InvokeEvent();
    }
}
