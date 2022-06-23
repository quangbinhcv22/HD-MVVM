namespace Game.Runtime
{
    public sealed class FixedUpdateHandler : ComponentEventHandler
    {
        private void FixedUpdate() => InvokeEvent();
    }
}