namespace Game.Runtime
{
    public sealed class DestroyHandler : ComponentEventHandler
    {
        private void OnDestroy() => InvokeEvent();
    }
}