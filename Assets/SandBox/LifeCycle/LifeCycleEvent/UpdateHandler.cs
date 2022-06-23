namespace Game.Runtime
{
    public sealed class UpdateHandler : ComponentEventHandler
    {
        private void Update() => InvokeEvent();
    }
}