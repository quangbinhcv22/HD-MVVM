namespace Game.Runtime
{
    public sealed class AwakeHandler : ComponentEventHandler
    {
        private void Awake() => InvokeEvent();
    }
}