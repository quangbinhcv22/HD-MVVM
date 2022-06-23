namespace Game.Runtime
{
    public sealed class MouseUpAsButtonHandler : ComponentEventHandler
    {
        private void OnMouseUpAsButton() => InvokeEvent();
    }
}