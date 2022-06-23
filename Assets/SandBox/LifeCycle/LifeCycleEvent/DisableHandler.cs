namespace Game.Runtime
{
    public sealed class DisableHandler : ComponentEventHandler
    {
        private void OnDisable() => InvokeEvent();
    }
}