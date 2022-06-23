namespace Game.Runtime
{
    public sealed class MouseDragHandler : ComponentEventHandler
    {
        private void OnMouseDrag() => InvokeEvent();
    }
}