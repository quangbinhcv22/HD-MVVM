namespace Game.Runtime
{
    public sealed class MouseDownHandler : ComponentEventHandler
    {
        private void OnMouseDown() => InvokeEvent();
    }
}