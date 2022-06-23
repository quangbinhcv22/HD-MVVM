namespace Game.Runtime
{
    public sealed class EnableHandler : ComponentEventHandler
    {
        private void OnEnable() => InvokeEvent();
    }
}