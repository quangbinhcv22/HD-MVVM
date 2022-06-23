namespace Game.Runtime
{
    public sealed class LateUpdateHandler : ComponentEventHandler
    {
        private void LateUpdate() => InvokeEvent();
    }
}