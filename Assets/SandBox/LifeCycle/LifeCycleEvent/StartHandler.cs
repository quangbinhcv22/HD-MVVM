namespace Game.Runtime
{
    public sealed class StartHandler : ComponentEventHandler
    {
        private void Start() => InvokeEvent();
    }
}