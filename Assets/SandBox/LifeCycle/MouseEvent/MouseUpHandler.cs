namespace Game.Runtime
{
    public sealed class MouseUpHandler : ComponentEventHandler
    {
        private void OnMouseUp() => InvokeEvent();
    }
}